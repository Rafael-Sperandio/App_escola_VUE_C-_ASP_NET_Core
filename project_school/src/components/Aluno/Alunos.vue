<template>
  <div >
    <titulo :texto="this.professor && this.professor.nome ? 'professor '+this.professor.nome: 'todos os aluno'"/>
    <!-- <div v-if="this.professorid">
      </div> -->
    <div v-if="this.professorid">
      <input  type="text" placeholder="Nome do aluno"
      v-model="nome" v-on:keyup.enter="addAluno()">
      <button class="btn btnCadastrar" @click="addAluno()">Adicionar</button>
    </div>
    
    <table  >
      <thead >
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="listaAlunos.length">
        <tr v-for="(aluno,index) in listaAlunos" :key="index">
          <!-- <td>{{index}}</td> -->
          <td class="tabelaFundoAzul">{{aluno.id}}</td>
          <router-link :to="'/alunodetalhe/'+aluno.id" tag="td" style="cursor: pointer;">
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
          <td class="tabelaFundoAzul">
            <button class="btn btn_remove" @click="remover(aluno)">remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else> nenhum aluno encontrado </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';
export default {
  components:{
      Titulo
  },
  props: {
  },
  data(){
    return {
      professorid: this.$route.params.prof_id, 
      listaAlunos: [
        //{id:1, nome:"joao"},
        //{id:2, nome:"ana"}
      ],
      professor: {}
    }
  },
  created(){
      if(this.professorid){
      this.buscaProfessor();
      this.$http.get('http://localhost:3000/alunos?professor.id='+this.professorid)
      .then(res =>res.json())
      .then(alunos => this.listaAlunos = alunos)

      }else{
              this.$http.get('http://localhost:3000/alunos')
      .then(res =>res.json())
      .then(alunos => this.listaAlunos = alunos)
      }

      //http://localhost:3000/alunos
      //npm install node@15
    },
  methods: {

    addAluno() {
      let _aluno = {
        nome : this.nome, 
        sobrenome: "",
        professor:{
          id:this.professor.id,
          nome:this.professor.nome,
        }
      };
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
    },
    buscaProfessor(){
      //precisar ter id entre apas ""
          this.$http.get('http://localhost:3000/professores/'+this.professorid)
          .then(res =>res.json())
          .then(professor => {
            this.professor = professor;
          })
    },
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.tabelaFundoAzul{
  background-color: rgb(125, 217, 245) ;
  width: 15%
}
.btnCadastrar{
  /*background-color: #3297ce; */
  width: 150px;
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
  width: calc(100% - 195px);
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;

}
</style>
