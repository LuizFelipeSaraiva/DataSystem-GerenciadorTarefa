import React, { Component } from 'react'
import TarefaService from '../services/TarefaService'

class ListaDeTarefasComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
                tarefas: []
        }
        this.criarTarefa = this.criarTarefa.bind(this);
        this.atualizarTarefa = this.atualizarTarefa.bind(this);
        this.excluirTarefa = this.excluirTarefa.bind(this);
    }

    criarTarefa(){
        this.props.history.push('/manter/_add');
    }

    atualizarTarefa(id){
        this.props.history.push(`/manter/${id}`);
    }

    excluirTarefa(id){
        TarefaService.excluirTarefa(id).then( res => {
            this.setState({tarefas: this.state.tarefas.filter(tarefa => tarefa.id !== id)});
        });
    }

    componentDidMount(){
        TarefaService.buscarTodasAsTarefas().then((res) => {
            if(res.data==null)
            {
                this.props.history.push('/manter/_add');
            }
            this.setState({ tarefas: res.data });
        });
    }

    formatarDatasTarefaParaFormatoBrasileiro = (dataISO) => {
        const data = new Date(dataISO); 
        return new Intl.DateTimeFormat('pt-BR').format(data);
    };

    formatarStatusTarefa = (numeroStatus) => {
        switch (numeroStatus) {
            case 1: return 'Pendente'
            case 2: return 'Em Progresso'
            case 3: return 'Concluída'
        }
    };

    changeStatusHandler = (event) => 
    {
        TarefaService.buscarTodasAsTarefas().then((res) => {
            if (event.target.value == 0)
            {
                this.setState({ tarefas: res.data });
            }
            else
            {
                this.setState({ tarefas: res.data.filter(tarefa => tarefa.status == event.target.value)});
            }
        });
    }

    render() {
        return (
            <div>
                 <h2 className="text-center">Lista de Tarefas</h2>
                 <div className = "row">
                        <button className="btn btn-primary" onClick={this.criarTarefa}> Criar Tarefa</button>
                 </div>
                 <div class="row">
                    <div className="form-group">
                        <label for="statusTarefa">Filtro por Status</label>
                        <select id="statusTarefa" name="status" value={this.state.status} className="form-control" onChange={this.changeStatusHandler}>
                            <option value="0">Todas</option>
                            <option value="1">Pendente</option>
                            <option value="2">Em Progresso</option>
                            <option value="3">Concluída</option>
                        </select>
                    </div>
                 </div>
                 <br></br>
                 <div className = "row">
                        <table className = "table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Título</th>
                                    <th>Descrição</th>
                                    <th>Status</th>
                                    <th>Data de Conclusão</th>
                                    <th>Data de Criação</th>
                                    <th>Opções</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.tarefas.map(
                                        tarefa => 
                                        <tr key = {tarefa.id}>
                                             <td> {tarefa.id} </td>  
                                             <td> {tarefa.titulo} </td>  
                                             <td> {tarefa.descricao} </td>
                                             <td> {this.formatarStatusTarefa(tarefa.status)} </td>
                                             <td> {this.formatarDatasTarefaParaFormatoBrasileiro(tarefa.dataDeConclusao)} </td>
                                             <td> {this.formatarDatasTarefaParaFormatoBrasileiro(tarefa.dataDeCriacao)} </td>
                                             <td>
                                                 <button onClick={ () => this.atualizarTarefa(tarefa.id)} className="btn btn-info">Atualizar Tarefa </button>
                                                 <button style={{marginLeft: "10px"}} onClick={ () => this.excluirTarefa(tarefa.id)} className="btn btn-danger">Excluir Tarefa </button>
                                             </td>
                                        </tr>
                                    )
                                }
                            </tbody>
                        </table>
                 </div>
            </div>
        )
    }
}

export default ListaDeTarefasComponent
