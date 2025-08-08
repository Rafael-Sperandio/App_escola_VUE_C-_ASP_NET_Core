<template>
    <div>
        <titulo :texto="'Aluno '+aluno.nome" :btnVoltar="this.editando">
            <button  v-if="!this.editando" @click="habilitaEdicao()"
            class="btn btnEditar btn-titulo">editar</button>
            <!-- <button v-else @click="desabilitaEdicao()"
            class="btn btn_remove btn-titulo"> cancelar</button> -->
        </titulo>
        <!-- <div class="botoes-div">
            <button  v-if="!this.editando" @click="habilitaEdicao()"
            class="btn btnEditar">editar</button>
            <button v-else @click="desabilitaEdicao()"
            class="btn btn_remove"> cancelar</button>
        </div> -->
        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matricula</td>
                    <td>
                        <label>{{aluno.id}}</label>
                    </td>
                </tr>
                <tr>
                     <td class="colPequeno">Nome</td>
                    <td>
                        <label v-if="!this.editando">{{aluno.nome}}</label>
                        <input v-else type="text" v-model="aluno.nome"/>
                    </td>
                </tr>
                <tr>
                     <td class="colPequeno">Sobrenome</td>
                    <td>
                        <label v-if="!this.editando">{{aluno.sobrenome}}</label>
                        <input v-else type="text" v-model="aluno.sobrenome"/>
                    </td>
                </tr>
                <tr>
                     <td class="colPequeno">Data Nacimento:</td>
                    <td>
                        <label v-if="!this.editando">{{aluno.dataNasc}}</label>
                        <input v-else type="text" v-model="aluno.dataNasc"/>
                    </td>
                </tr>
                <tr>
                     <td class="colPequeno">Professor</td>
                    <td>
                        <label v-if="!this.editando">{{aluno.professor.nome}}</label>
                        <select v-else v-model="aluno.professor">
                            <option v-for="(professor, index) in listaProfessores" 
                            :key="index" v-bind:value="professor">
                                {{ professor.nome }}
                            </option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="botoes-div">
            <button v-if="this.editando" @click="cancelar()"
            class="btn btn_remove"> cancelar</button>
            <button  v-if="this.editando" @click="salvar()"
            class="btn btnEditar">salvar</button>

        </div>
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
        nome: '',
        aluno: {},
        alunoId: this.$route.params.id, 
        listaProfessores: [
        ],
        professor:{},
        editando: false,
    }
  },
  created(){
    this.buscaAluno();
    this.buscaProfessores();
  },
  methods: {
        habilitaEdicao(){
            this.editando=true;
        },
        salvar(){
            let _alunoEditar= {"id": this.aluno.id,
                        "nome": this.aluno.nome,
                        "sobrenome": this.aluno.sobrenome,
                        "dataNasc":this.aluno.dataNasc,
                        "professor": this.aluno.professor,
            }
            this.$http.put('http://localhost:3000/alunos/'+this.aluno.id,_alunoEditar);
            this.editando=false; 
        },
        cancelar(){
          this.editando=false; 
        },
        buscaAluno(){
      //precisar ter id entre apas ""
          this.$http.get('http://localhost:3000/alunos/'+this.alunoId)
          .then(res =>res.json())
          .then(aluno => {
            this.aluno = aluno;
          })
        },
        buscaProfessores(){
          this.$http.get('http://localhost:3000/professores')
          .then(res =>res.json())
          .then(professores => {
            this.listaProfessores = professores;
          })
          }
  },
}
    
</script>

<style scoped>
.botoes-div{
    display: flex;
    justify-content: space-between;
    width: 100%;
    padding: 10px 0px;
}
.colPequeno {
  width: 20%;
  text-align: right;
  background-color: rgb(125, 217, 245) ;
  font-weight: bold;
}
input, select{
    margin: 0px;
    padding: 5px 10px;
    font-size: 0.9em;
    /* font-family: Montserrat; */
    border: 1px solid silver;
    border-radius: 5px;
    width: 95%;
    background-color: rgb(245, 245, 245);
}
select{
    height: 38px;
    width: 100%;
}
.btn-titulo{
    float: right;
}

.btnEditar{
    /*background-color: #3297ce; */
    /* width: 150px; */
    background-color: rgb(76, 186, 249);
    color: white;
     font-size: 1.2em;   
    /* display: inline; 

    padding: 20px;
    border: 0px;
    font-size: 1.3em; */
}
.btnEditar:hover{
  /* padding: 20px;
  margin-top: 0px;
  border: 0px; */   
}


</style>