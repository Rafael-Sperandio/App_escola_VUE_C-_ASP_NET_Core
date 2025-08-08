import Vue from 'vue'
import Router from 'vue-router'
import Sobre from './components/Sobre/Sobre'
import Professores from './components/Professor/Professor.vue'
import Alunos from './components/Aluno/Alunos.vue'
import AlunoDetalhe from './components/Aluno/AlunoDetalhe.vue'
Vue.use(Router)
export default new Router({
    routes:[
        {
            path:'/professores',
            nome:'Professores',
            component: Professores
        },
        {
            path:'/alunos/:prof_id',
            nome:'Alunos',
            component: Alunos
        },
        {
            path:'/todosalunos/',
            nome:'Alunos',
            component: Alunos
        },
                {
            path:'/alunodetalhe/:id',
            nome:'AlunoDetalhe',
            component: AlunoDetalhe
        },
        {
            path:'/sobre',
            nome:'Sobre',
            component: Sobre
        },
    ]
})