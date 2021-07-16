import { http } from './config'

export default {
    listar: () => {
        return http.get('desenvolvedor')
    },

    salvar: (desenvolvedor) => {
        return http.post('desenvolvedor', desenvolvedor)
    },

    atualizar: (desenvolvedor) => {
        return http.put('desenvolvedor', desenvolvedor)
    },

    excluir: (desenvolvedor) => {           
        return http.delete('desenvolvedor', {headers : desenvolvedor} )
    },
    pesquisarId: (id_dev) => {        
        return http.get('desenvolvedor/' + id_dev)
    },

    pesquisarGeral: (string_pesquisa) => {
        return http.get('desenvolvedor/GetByQueryString/' + string_pesquisa)
    }
}