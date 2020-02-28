import axios from '@/service/index';

const state = {
    data:[],
    obj: {
        email: null,
        password: null,
    }
}

const mutations = {
	INIT_DATA: (state, payload) => {
        state.data = payload
    },
    UPDATE_DATA_BYID: (state, payload) => {
        const index = state.data.findIndex(data => data.id == payload.id)
        state.data.splice(index, 1)
        state.data.push(payload)
    },
    ADD_DATA: (state, payload) => {
        state.data.push(payload)
    },
    DELETE_DATA: (state, payload) => {
        const index = state.data.findIndex(data => data.id == payload)
        state.data.splice(index, 1)
    },
    UPDATE_OBJ: (state, payload) => {
        state.obj = payload
    },
    SET_FK_ID: (state, payload) => {
        state.obj.employee_id = payload
    },
    SET_CHECKBOX: (state, payload) => {
        state.obj.id = payload
        state.obj.employee_id = payload
    },
    CLEAR_OBJ: (state) => {
        state.obj = {
            email: null,
            password: null,
        }
    },
    UPDATE_OBJ_BY_KEY: (state, {
        key,
        data
    }) => {
        state.obj[key] = data
    },
}

const getters = {
  data: state => state.data,
  getById: (state) => (id) => {
    return state.data.find(data => data.id == id)
  },
  getObj: state => state.obj,
}

const actions = {
    login: (context) => {
        const obj = {
            email: state.obj.email,
            password: state.obj.password,
        }
        return new Promise((resolve, reject) => {
            console.log(obj,axios); //ssss@sss.vob
            axios.post("/api/Member/login", obj)
            .then(response => {
                console.log(response);    
                localStorage.setItem('jwt',response.data.jwt_token);
                // context.commit("ADD_DATA", obj)
                resolve(response);
            }, error => {
                reject(error);
            });
        })
    },
    updateObj: (context, payload) => {
        context.commit("UPDATE_OBJ", payload)
    },
    clearObj: (context) => {
        context.commit("CLEAR_OBJ")
    },
    updateObjByKey: (context, payload) => {
        const key = payload.key;
        const data = payload.data;
        context.commit("UPDATE_OBJ_BY_KEY", {
            key,
            data
        })
    },
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
