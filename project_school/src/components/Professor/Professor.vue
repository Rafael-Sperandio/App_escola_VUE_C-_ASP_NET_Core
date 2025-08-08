<template>
    <div>
    <Titulo texto="Professores"/>
    <table  >
      <thead >
        <th>codigo</th>
        <th>Nome</th>
        <th>quantidade</th>
      </thead>
      <tbody v-if="listaProfessores.length">
        <tr v-for="(Professor,index) in listaProfessores" :key="index">
          <!-- <td>{{index}}</td> -->
          <td class="colPequeno">{{Professor.id}}</td>
          <router-link :to="'/alunos/'+ Professor.id" tag="td" style="cursor: pointer;">
          <!-- <router-link to='/alunos' tag="td" style="cursor: pointer;"> -->
            {{Professor.nome}}
          </router-link>
          <td class="colPequeno">
             {{Professor.qtd}}
          </td>
        </tr>
      </tbody>
      <tfoot v-else> nenhum profesor encontrado </tfoot>
    </table>
    </div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';
    export default {
        components:{
            Titulo
        },

        data(){
            return {
                listaProfessores: [
                ],
                alunos:[]
            }
            
        },
        methods: {
          QtdAlunosPorProfesor(){
            this.listaProfessores.forEach((professor,index) => {
              
              professor = {
                id: professor.id,
                nome: professor.nome,
                qtd: this.alunos.filter(aluno => 
                aluno.professor.id ==  professor.id).length
              }
              this.listaProfessores[index]=professor;
            });
          },
          buscaProfessores(){
          this.$http.get('http://localhost:3000/professores')
          .then(res =>res.json())
          .then(professores => {
            this.listaProfessores = professores;
            this.QtdAlunosPorProfesor();
          })
          }
        },
        created(){
          this.$http.get('http://localhost:3000/alunos')
          .then(res =>res.json())
          .then(alunos => {
            this.alunos = alunos
            this.buscaProfessores();
          }
          )

        },
    }
</script>

<style scoped>
.colPequeno {
  width: 15%;
  text-align: center;
  background-color: rgb(125, 217, 245) ;
  font-weight: bold;
}
</style>