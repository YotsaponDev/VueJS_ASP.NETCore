import axios from '@/service/index';

const state = {
    data:[],
    obj: {
        book_id: null,
        name: null,
        detail: null,
        author: null,
        publisher: null,
        book_category_id: null,
        number_of_page: null,
        image: null,

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
    CLEAR_OBJ: (state) => {
        state.obj = {
            book_id: null,
            name: null,
            detail: null,
            author: null,
            publisher: null,
            book_category_id: null,
            number_of_page: null,
            image: null,
    
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
            axios.get("/api/Book").then(response => {
                context.commit("INIT_DATA", response.data)                
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        })
    },
    postData: (context) => {
        const obj = {
            name: state.obj.name,
            detail: state.obj.detail,
            author: state.obj.author,
            publisher: state.obj.publisher,
            book_category_id: state.obj.book_category_id,
            number_of_page: state.obj.number_of_page,
            image: state.obj.image,

            created_at: new Date(),
            updated_at: null
        }
        return new Promise((resolve, reject) => {
            axios.post("/api/Book", obj)
            .then(response => {
                context.commit("ADD_DATA", obj)
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        })
    },
    updateData: (context) => {
        return new Promise((resolve, reject) => {
            axios.put("/api/Book/" + state.obj.book_category_id, {
                name: state.obj.name,
                detail: state.obj.detail,
                author: state.obj.author,
                publisher: state.obj.publisher,
                book_category_id: state.obj.book_category_id,
                number_of_page: state.obj.number_of_page,
                image: state.obj.image,
                
                updated_at: new Date()
            })
            .then(response => {
                context.commit("UPDATE_DATA_BYID", response.data)
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        })
    },
    deleteData: (context, payload) => {
        return new Promise((resolve, reject) => {
            axios.delete("/api/Book/" + payload)
            .then(response => {
                context.commit("DELETE_DATA", payload)
                resolve(response);
            }).catch(error => {
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
