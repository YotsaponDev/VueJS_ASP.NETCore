<template>
  <layout>
    <div class="container">
      <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
      <ValidationObserver v-slot="{ handleSubmit }">
        <b-card title="จัดการหมวดหมู่หนังสือ" body-class="text-center">
          <b-card-text>
            <b-row>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-sm-right" name="รหัสหมวดหมู่" v-slot="{ errors }" rules="required">
                  <b-form inline>
                    <label class="mr-sm-2">รหัสหมวดหมู่</label>
                    <b-form-input v-model="code" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider name="ชื่อหมวดหมู่" class="float-sm-left" v-slot="{ errors }" rules="required">
                  <b-form inline>
                    <label class="mr-sm-2">ชื่อหมวดหมู่</label>
                    <b-form-input v-model="name" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-2 mb-sm-3">
                <b-form inline class="justify-content-center">
                  <b-button class="mr-2" @click.prevent="handleSubmit(saveEvent)" variant="primary">บันทึก
                  </b-button>
                  <b-button variant="danger" @click="cancelEvent()">ยกเลิก</b-button>
                </b-form>
              </b-col>
            </b-row>
          </b-card-text>
          
        </b-card>
      </ValidationObserver>
    </div>
  </layout>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  import layout from '@/components/layout'
  export default {
    components: {
      layout
    },
    data() {
      return {
        loadingActive: false
      }
    },
    created() {
      
    },
    mounted(){
      
    },
    beforeDestroy() {
      this.clearObj()
    },
    methods: {
      ...mapActions("book_category", ["postData","updateData","clearObj"]),
      saveEvent() {
        if(this.$route.params.action.toLowerCase() == "create"){
          this.loadingActive = true
          this.postData().then(res => {
            this.loadingActive = false
            this.$swal({
              icon: 'success',
              title: 'เพิ่มรายการสำเร็จ',
              showConfirmButton: false,
              timer: 3000
            }).then((result) => {
              this.$router.push({
                name: 'book_category'
              })                      
            });
          }).catch(err => {
            this.loadingActive = false
            this.$swal({
              icon: 'error',
              title: 'เกิดข้อผิดพลาด',
              text: err.response.data,
              footer: 'หรือติดต่อเจ้าหน้าที่'
            });
          })
        }else if(this.$route.params.action.toLowerCase() == "update"){
          this.loadingActive = true
          this.updateData().then(res => {
            this.loadingActive = false
            this.$swal({
              icon: 'success',
              title: 'แก้ไขรายการสำเร็จ',
              showConfirmButton: false,
              timer: 2000
            }).then((result) => {
              if(result.value){
                this.$router.push({
                  name: 'book_category'
                })
              }
            });
          }).catch(err => {
            this.loadingActive = false
            this.$swal({
              icon: 'error',
              title: 'เกิดข้อผิดพลาด',
              text: err.response.data,
              footer: 'หรือติดต่อเจ้าหน้าที่'
            });
          })
        }else{
          this.$swal({
            icon: 'error',
            title: 'เกิดข้อผิดพลาดจาก URL',
            text: 'กรุณากลับมาหน้านี้อีกครั้งในภายหลัง',
          });
        }
        
      },
      cancelEvent(){
        this.$router.push({
          name: 'book_category'
        })
      }
    },
    computed: {
      ...mapGetters({
        data: "book_category/data",
        obj: "book_category/getObj"
      }),
      code: {
        get() {
          return this.obj.code
        },
        set(data) {
          var key = "code"
          this.$store.commit('book_category/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      name: {
        get() {
          return this.obj.name
        },
        set(data) {
          var key = "name"
          this.$store.commit('book_category/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
    },
    watch: {
      data: function(val){
        
      }
    },
  }
</script>