<template>
     <div>
         <ValidationProvider class="float-center" name="หมวดหมู่" v-slot="{ errors }" rules="required">

                <b-form-select v-model="select" :options="options"
                    :value-field="pValueField" :text-field="pTextField">
                </b-form-select>

            <span id="errorValidate">{{ errors[0] }}</span>
        </ValidationProvider>
    </div>
</template>

<script>
import { mapActions , mapGetters } from "vuex";
export default {
    props: ["pStore","pKey","pValueField","pTextField","pType","pData"],
    data() {
      return {
        options: []
      }
    },
    created() {        
        let option_tyle = this.pType // array || link
          if(option_tyle == "array"){
            return 
          }else if(option_tyle == "link"){
            this.$axios.get(this.pData)
            .then(res => {
                this.options = res.data
            }).catch(err => {
                console.log('err:' , err);
            });
          }else{
            return []
          }
      
    },
    computed: {
        obj: {
            get(){
                return this.$store.getters[this.pStore+'/getObj']
            }
        },
        select: {
            get() {
                return this.obj[this.pKey]
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
}
</script>
