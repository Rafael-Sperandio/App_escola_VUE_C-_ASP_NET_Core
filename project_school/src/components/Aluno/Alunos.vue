<template>
  <div >
    <titulo texto="aluno"/>
    <input type="text" placeholder="Nome do aluno"
    v-model="nome" v-on:keyup.enter="addAluno()">
    <button class="btn btnCadastrar" @click="addAluno()">Adicionar</button>
    <table  >
      <thead >
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="listaAlunos.length">
        <tr v-for="(aluno,index) in listaAlunos" :key="index">
          <!-- <td>{{index}}</td> -->
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}}</td>
          <td>
            <button class="btn btn_remove" @click="remover(aluno)">remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else> nenhum aluno encontrado </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../Share/Titulo.vue';
export default {
  components:{
      Titulo
  },
  props: {
  },
  data(){
    return {
      // titulo: "aluno",
      nome: '',
      listaAlunos: [
        //{id:1, nome:"joao"},
        //{id:2, nome:"ana"}
      ]
    }
  },
  created(){
      this.$http.get('http://localhost:3000/alunos')
      .then(res =>res.json())
      .then(alunos => this.listaAlunos = alunos)
      //http://localhost:3000/alunos
      //npm install node@15
    },
  methods: {

    addAluno() {
      let _aluno = {nome : this.nome}
      this.$http.post('http://localhost:3000/alunos',_aluno)
      .then(res =>res.json())
      .then(alunoRetornado => 
      {
        this.listaAlunos.push(alunoRetornado)
      })
    
      this.nome = '';
    },
    remover(aluno){
      //aluno
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then( () => {
        let index = this.listaAlunos.indexOf(aluno);
        this.listaAlunos.splice(index,1);
      }
      )

      
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.btnCadastrar{
  /*background-color: #3297ce; */
  background-color: rgb(116, 115, 115); 
  display: inline;
  color: white;
  padding: 20px;
  border: 0px;
  font-size: 1.3em;
}
.btnCadastrar:hover{
  padding: 20px;
  margin-top: 0px;
  border: 0px;
}
input{
  /* width: 100%; */
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;

}
</style>
