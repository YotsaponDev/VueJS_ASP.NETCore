<template>
     <div>
        <ValidationProvider class="float-center" :name="pName" v-slot="{ errors }" :rules="dataRequired">
            <b-form class="text-left">
                <b-form-file
                    v-model="file"
                    :accept="pAccept"
                    placeholder="เลือกไฟล์หรือลากไฟล์มาวางทีนี่..."
                    drop-placeholder="ลากไฟล์มาวางทีนี่..."
                    @change="changeFile($event)"
                ></b-form-file>
            </b-form>
            <span id="errorValidate">{{ errors[0] }}</span>
        </ValidationProvider>
    </div>
</template>

<script>
import { mapActions , mapGetters } from "vuex";
export default {
    props: ["pStore","pKey","pName","pAccept","pRequired"],
    data() {
      return {
          dataRequired: null
      }
    },
    created() {        
      this.dataRequired = this.pRequired
    },
    methods: {
        changeFile(e){
            // console.log("eerwerewr",e.target.files[0]);
        }
    },
    computed: {
        obj: {
            get(){
                return this.$store.getters[this.pStore+'/getObj']
            }
        },
        file: {
            get() {
                if(typeof this.obj[this.pKey] == 'object'){
                    if(this.obj[this.pKey]){
                        document.getElementsByClassName('custom-file-label')[0].innerHTML = this.obj[this.pKey]["name"]
                        return [this.obj[this.pKey]]
                    }
                    
                }else{
                    if(this.pRequired){
                        console.log("zzzzzz");
                        
                        if(this.obj[this.pKey]){
                            this.dataRequired = ""
                        }
                    }
                    document.getElementsByClassName('custom-file-label')[0].innerHTML = this.obj[this.pKey]
                }
                
            },
            set(data) {
                var key = this.pKey
                this.$store.commit(this.pStore+'/UPDATE_OBJ_BY_KEY', {
                    key,
                    data
                })
            }
        },
    },
    watch: {
        obj: function(val){
            if(typeof this.obj[this.pKey] != 'object'){
                console.log("watccc");
                // document.getElementsByClassName('custom-file-label')[0].innerHTML = val.image
            }
        }
    },
}
</script>
