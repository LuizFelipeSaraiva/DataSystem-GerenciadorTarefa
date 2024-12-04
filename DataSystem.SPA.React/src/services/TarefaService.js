import axios from 'axios';

const TAREFAS_API_BASE_URL = "http://localhost:12301/api/tarefa";

class TarefaService {

    buscarTodasAsTarefas(){
        return axios.get(TAREFAS_API_BASE_URL);
    }

    buscarTarefaPeloId(tarefaId){
        return axios.get(TAREFAS_API_BASE_URL + '/BuscarTarefaPeloId/' + tarefaId);
    }

    buscarTarefasPeloStatus(tarefaStatus){
        return axios.get(TAREFAS_API_BASE_URL + '/' + tarefaStatus);
    }

    criarTarefa(tarefa)
    {
        return axios.post(TAREFAS_API_BASE_URL, tarefa)
            .then((response) => {
                return response.data;
            })
            .catch((error) => {
                if (error.response && error.response.data.message) {
                    return Promise.reject(error.response.data.message);
                }
                return Promise.reject(["Erro inesperado. Tente novamente mais tarde."]);
            });
    }

    atualizarTarefa(tarefa){
        return axios.put(TAREFAS_API_BASE_URL, tarefa)
            .then((response) => {
                return response.data;
            })
            .catch((error) => {
                if (error.response && error.response.data.message) {
                    return Promise.reject(error.response.data.message);
                }
                return Promise.reject(["Erro inesperado. Tente novamente mais tarde."]);
            });
    }

    excluirTarefa(tarefaId){
        return axios.delete(TAREFAS_API_BASE_URL + '/ExcluirTarefa/' + tarefaId);
    }
}

export default new TarefaService()