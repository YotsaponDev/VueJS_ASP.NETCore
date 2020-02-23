import axios from '@/service/index';

const state = {
    data:[],
    obj: {
        member_id: null,
        firstname: null,
        lastname: null,
        birthday: null,
        sex: null,
        email: null,
        password: null,

        created_at: "",
        updated_at: ""
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
            member_id: null,
            firstname: null,
            lastname: null,
            birthday: null,
            sex: null,
            email: null,
            password: null,
    
            created_at: "",
            updated_at: ""
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
    initData: (context,payload) => {
        return new Promise((resolve, reject) => {
            axios.get("/api/register/"+payload).then(response => {
                context.commit("INIT_DATA", response.data)                
                resolve(response);
            }, error => {
                reject(error);
            });
        })
    },
    postData: (context) => {
        const obj = {
            firstname: state.obj.firstname,
            lastname: state.obj.lastname,
            birthday: state.obj.birthday,
            sex: state.obj.sex,
            email: state.obj.email,
            password: state.obj.password,

            created_at: new Date(),
            updated_at: null
        }
        return new Promise((resolve, reject) => {
            console.log(obj,axios); //ssss@sss.vob
            axios.post("/api/Member", obj)
            .then(response => {
                // context.commit("ADD_DATA", obj)
                resolve(response);
            }, error => {
                reject(error);
            });
        })
    },
    updateData: (context) => {
        return new Promise((resolve, reject) => {
            axios.put("/api/Member/" + state.obj.member_id, {
                firstname: state.obj.firstname,
                lastname: state.obj.lastname,
                birthday: state.obj.birthday,
                sex: state.obj.sex,
                email: state.obj.email,
                password: state.obj.password,
                updated_at: new Date()
            })
            .then(response => {
                context.commit("UPDATE_DATA_BYID", payload)
                resolve(response);
            }, error => {
                reject(error);
            });
        })
    },
    deleteData: (context, payload) => {
        return new Promise((resolve, reject) => {
            axios.delete("/api/Member/" + payload)
            .then(response => {
                context.commit("DELETE_DATA", payload)
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
