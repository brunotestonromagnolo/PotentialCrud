<template>
  <div id="app">

    <nav>
      <div class="nav-wrapper blue darken-1">
        <a href="#" class="brand-logo center">Potential Crud - Front</a>
      </div>
    </nav>

    <div class="container">

      <!-- Erros ocorridos -->      
      <p v-if="errors">                
        <ul>
          <li  v-for="error in errors" :key="error"> <p style="color:red;"> {{ error }} </p> </li>
        </ul>
      </p>      

      <!-- Validacao de campos -->
      <p v-if="errorFields.length">
        <b>Por favor, corrija o(s) seguinte(s) erro(s):</b>
        <ul>
          <li  v-for="error in errorFields" :key="error"> <p style="color:red;"> {{ error }} </p> </li>
        </ul>
      </p> 

      <form @submit.prevent="salvar">
          <label>Nome</label>
          <input type="text" placeholder="Nome" v-model="desenvolvedor.nome" required >
          <label>Sexo</label>
          <input type="text" placeholder="Sexo" v-model="desenvolvedor.sexo" required>          
          <label>Idade</label>
          <input type="number" placeholder="Idade" v-model.number="desenvolvedor.idade" min="1" required >
          <label>Hobby</label>
          <input type="text" placeholder="Hobby" v-model="desenvolvedor.hobby" required>
          <label>Data Nascimento</label>
          <input type="date" placeholder="Data de nascimento" v-model="desenvolvedor.dataNascimento" required>
          <button class="waves-effect waves-light btn-small">Salvar<i class="material-icons left">save</i></button>
      </form>            
      
      <p class="exPesquisa"> Pesquisa </p>      
      <form @submit.prevent="pesquisarid">
        <label>Pesquisar por Id</label> 
        <input type="text" placeholder="Id" v-model="id_pesquisa" >
        <button class="waves-effect waves-light btn-small">Pesquisar Id<i class="material-icons left">find_in_page</i></button>
      </form>
      
      <form @submit.prevent="pesquisarGeral">
        <label>Pesquisar geral</label>
        <input type="text" placeholder="" v-model="string_pesquisa" >
        <button class="waves-effect waves-light btn-small">Pesquisar Geral<i class="material-icons left">find_in_page</i></button>
      </form>      

      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>NOME</th>
            <th>Sexo</th>
            <th>Idade</th>
            <th>Hobby</th>
            <th>Data Nascimento</th>            
            <th>OPÇÕES</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="desenvolvedor of desenvolvedores" :key="desenvolvedor.id">
            <td>{{ desenvolvedor.id }}</td>
            <td>{{ desenvolvedor.nome }}</td>
            <td>{{ desenvolvedor.sexo }}</td>
            <td>{{ desenvolvedor.idade }}</td>
            <td>{{ desenvolvedor.hobby }}</td>
            <td>{{ format_date(desenvolvedor.dataNascimento) }}</td>                        
            <td>
              <button @click="editar(desenvolvedor)" class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
              <button @click="remover(desenvolvedor)" class="waves-effect btn-small red darken-1"><i class="material-icons">delete_sweep</i></button>
            </td>
          </tr>
        </tbody>      
      </table>

    </div>

  </div>
</template>

<script>

import DesenvolvedorApi from './services/desenvolvedores';
import moment from 'moment';

export default {
  name: 'app',
  data () {
    return {
      desenvolvedor:{
        id: 0,
        nome: '',
        sexo: '',
        idade: '',
        hobby: '',
        dataNascimento: ''
      },
      desenvolvedores: [],
      errors: [],
      errorFields: [],
      id_pesquisa : '',
      string_pesquisa: ''
    }
  },

  mounted(){
    this.listar()
  },

  methods:{
    
    listar(){
      DesenvolvedorApi.listar().then(resposta => {
        this.desenvolvedores = resposta.data        
      }).catch(e => {
        console.log(e)
      })
    },

    salvar(){
      this.validarCampos()      
      if (this.errorFields.length > 0){
        return;
      }

      if(!this.desenvolvedor.id){
        DesenvolvedorApi.salvar(this.desenvolvedor).then(() => {
          this.desenvolvedor = {}
          this.errors = {}
          this.listar()          
          alert('Cadastrado com sucesso!')
        }).catch(e => {
          console.log(e.response)
          this.errors = e.response          
        })

      }else{
        DesenvolvedorApi.atualizar(this.desenvolvedor).then(() => {
          this.desenvolvedor = {}
          this.errors = {}          
          this.listar()
          alert('Atualizado com sucesso!')          
        }).catch(e => {
          this.errors = e.response
          console.log(this.errors)
        })
      }
    },

    editar(desenvolvedor){
      this.desenvolvedor = desenvolvedor      
    },

    remover(desenvolvedor){
      if(confirm('Deseja mesmo excluir?')){
        DesenvolvedorApi.excluir(desenvolvedor).then(() => {
          this.listar()          
          this.errors = {}          
        }).catch(e => {
          this.errors = e.response.data.errors
        })
      }
    },

    pesquisarid(){      
      DesenvolvedorApi.pesquisarId(this.id_pesquisa).then( resposta => {
        this.desenvolvedores = resposta.data        
      }).catch(() => {
        this.desenvolvedores = []       
      })
    },

    pesquisarGeral(){ 
      if (this.string_pesquisa){
        DesenvolvedorApi.pesquisarGeral(this.string_pesquisa).then( resposta => {
          this.desenvolvedores = resposta.data
      })
      }
      else{
        this.listar()
      }
    },

    validarCampos(){
      this.errorFields = []      
      if (this.desenvolvedor.sexo.toUpperCase() !== 'M' && this.desenvolvedor.sexo.toUpperCase() !== 'F'){        
        this.errorFields.push('Campo "Sexo" está inválido! Deve ser informado M ou F', );
      }      
    },

    format_date(value){
         if (value) {
           return moment(String(value)).format('DD/MM/YYYY')
          }
      }
  }

}
</script>

<style>
  p.exPesquisa {
    font-size: 25px;
  }
</style>
