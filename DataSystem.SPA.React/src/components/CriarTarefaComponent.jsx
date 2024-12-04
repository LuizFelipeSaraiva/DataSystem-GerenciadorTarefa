import React, { Component } from 'react'
import TarefaService from '../services/TarefaService';

class CriarTarefaComponent extends Component {
    constructor(props) {
        super(props)
        this.state = {
            
            id: this.props.match.params.id,
            titulo: '',
            descricao: '',
            dataDeConclusao: this.formatarDataParaSerExibidaNoCampo(new Date().toISOString()),
            dataDeCriacao: '',
            status: 1,
            errorMessage: ''
        }
        this.changeTituloHandler = this.changeTituloHandler.bind(this);
        this.changeDescricaoHandler = this.changeDescricaoHandler.bind(this);
        this.changeDataDeConclusaoHandler = this.changeDataDeConclusaoHandler.bind(this);
        this.changeDataDeCriacaoHandler = this.changeDataDeCriacaoHandler.bind(this);
        this.changeStatusHandler = this.changeStatusHandler.bind(this);
    }

    componentDidMount() {
        if (this.state.id === '_add') {
            return
        } else {
            TarefaService.buscarTarefaPeloId(this.state.id).then((res) => {
                let tarefa = res.data;
                this.setState({
                    id: tarefa.id,
                    titulo: tarefa.titulo,
                    descricao: tarefa.descricao,
                    dataDeConclusao: this.formatarDataParaSerExibidaNoCampo(tarefa.dataDeConclusao),
                    dataDeCriacao: this.formatarDataParaSerExibidaNoCampo(tarefa.dataDeCriacao),
                    status: tarefa.status
                });
            });
        }
    }
    
    criarAtualizarTarefa = (e) => {
        e.preventDefault();
        
        let tarefaCommand = { 
            id: this.state.id,
            titulo: this.state.titulo, 
            descricao: this.state.descricao, 
            dataDeConclusao: this.state.dataDeConclusao,
            dataDeCriacao: this.state.dataDeCriacao,
            status: this.state.status, 
        };

        console.log('tarefa => ' + JSON.stringify(tarefaCommand));
     
        if (this.state.id === '_add') 
        {
            TarefaService.criarTarefa(tarefaCommand)
                .then((res) => {
                    this.props.history.push('/tarefas');
                })
                .catch((errorMessages) => {
                    this.setState({errorMessage: errorMessages})
                });
        } 
        else 
        {
            TarefaService.atualizarTarefa(tarefaCommand).then(res => {
                this.props.history.push('/tarefas');
            })
            .catch((errorMessages) => {
                this.setState({errorMessage: errorMessages})
            });
        }
    }

    changeTituloHandler = (event) => {
        this.setState({ titulo: event.target.value });
    }

    changeDescricaoHandler = (event) => {
        this.setState({ descricao: event.target.value });
    }

    changeDataDeConclusaoHandler = (event) => {
        this.setState({ dataDeConclusao: event.target.value });
    }

    changeDataDeCriacaoHandler = (event) => {
        this.setState({ dataDeCriacao: event.target.value });
    }

    changeStatusHandler = (event) => {
        this.setState({ status: Number(event.target.value) });
    }

    cancel() {
        this.props.history.push('/tarefas');
    }

    gerarTituloDaPagina() {
        if (this.state.id === '_add') {
            return <h3 className="text-center">Criar Tarefa</h3>
        } else {
            return <h3 className="text-center">Atualizar Tarefa</h3>
        }
    }

    formatarDataParaSerExibidaNoCampo = (dataISO) => {
        return dataISO.split('T')[0]
    };

    render() {
        return (
            <div>
                <br></br>
                <div className="container">
                    <div className="row">
                        <div className="card col-md-6 offset-md-3 offset-md-3">
                            {
                                this.gerarTituloDaPagina()
                            }
                            <div className="card-body">
                                <form>
                                    <div className="form-group">
                                        <label> Título: </label>
                                        <input placeholder="Título" name="titulo" className="form-control"
                                            value={this.state.titulo} onChange={this.changeTituloHandler}/>
                                    </div>
                                    <div className="form-group">
                                        <label> Descrição: </label>
                                        <input placeholder="Descrição" name="Descricao" className="form-control"
                                            value={this.state.descricao} onChange={this.changeDescricaoHandler} maxLength={150}/>
                                    </div>
                                    <div className="form-group">
                                        <label> Data de Conclusão: </label>
                                        <input type="date" name="dataDeConclusao" className="form-control"
                                            value={this.state.dataDeConclusao} onChange={this.changeDataDeConclusaoHandler} />
                                    </div>

                                    <div className="form-group">
                                        <label> Status: </label>
                                        <select name="status" value={this.state.status} className="form-control" onChange={this.changeStatusHandler}>
                                            <option value="1">Pendente</option>
                                            <option value="2">Em Progresso</option>
                                            <option value="3">Concluída</option>
                                        </select>
                                    </div>
                                    <button className="btn btn-success" onClick={this.criarAtualizarTarefa}>Salvar</button>
                                    <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{ marginLeft: "10px" }}>Cancelar</button>
                                </form>
                                <br/>
                                { this.state.errorMessage && <p className="alert alert-danger"> { this.state.errorMessage } </p> }
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default CriarTarefaComponent
