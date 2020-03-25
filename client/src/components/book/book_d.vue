<template>
  <layout>
    <div class="container">
      <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
      <ValidationObserver v-slot="{ handleSubmit }">
        <b-card title="จัดการหนังสือ" body-class="text-center">
          <b-card-text>
            <b-row>
              <b-col sm="12" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-center" name="ชื่อหนังสือ" v-slot="{ errors }" rules="required">
                  <b-form class="text-left">
                    <label class="mr-sm-2">ชื่อหนังสือ</label>
                    <b-form-input v-model="name" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col sm="12" class="mb-2 mb-sm-3">
                <ValidationProvider name="รายละเอียด" class="float-center" v-slot="{ errors }" rules="required">
                  <b-form class="text-left">
                    <label class="mr-sm-2">รายละเอียด</label>
                    <b-form-textarea v-model="detail" rows="3" max-rows="6"></b-form-textarea>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-center" name="ผู้แต่ง" v-slot="{ errors }" rules="required">
                  <b-form class="text-left">
                    <label class="mr-sm-2">ผู้แต่ง</label>
                    <b-form-input v-model="author" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-center" name="สำนักพิมพ์" v-slot="{ errors }" rules="required">
                  <b-form class="text-left">
                    <label class="mr-sm-2">สำนักพิมพ์</label>
                    <b-form-input v-model="publisher" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col sm="7" class="mb-2 mb-sm-3">
                <label class="mr-sm-2">หมวดหมู่</label>
                <FormSelect pStore="book" pKey="book_category_id" pValueField="book_category_id" 
                  pTextField="name" pType="link" pData="/api/bookCategory"></FormSelect>
              </b-col>
              <b-col sm="5" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-center" name="จำนวนหน้า" v-slot="{ errors }" rules="required">
                  <b-form class="text-left">
                    <label class="mr-sm-2">จำนวนหน้า</label>
                      <b-form-input v-model="number_of_page" type="number"></b-form-input>
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
  import { FormSelect } from '@/components/form'
  export default {
    components: {
      layout,
      FormSelect
    },
    data() {
      return {
        loadingActive: false
      }
    },
    async created() {
      this.loadingActive = true
      await this.initData().then(res => {
            this.loadingActive = false
      }).catch(err=>{
        this.loadingActive = false
      })
    },
    async mounted(){
      await this.$axios.get('/api/BookCategory')
            .then(res => {
              console.log(res.data);
              
              return res.data
            })
            .catch(err => {
                console.log('err:' , err);
            });
    },
    beforeDestroy() {
      this.clearObj()
    },
    methods: {
      ...mapActions("book", ["initData","postData","updateData","updateObj","clearObj"]),
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
                name: 'book'
              })                      
            });
          }).catch(err => {
            this.loadingActive = false
            if(err.response){
              if(err.response.status == 401){
                this.$swal({
                  icon: 'error',
                  title: 'ไม่สามารถทำรายการได้',
                  text: 'ผู้ใช้งานต้องทำการพิสูจน์ตัวตนก่อน'
                });
              }else{
                this.$swal({
                  icon: 'error',
                  title: 'ไม่สามารถทำรายการได้',
                  text: ''
                });
              }
            }else{
              this.$swal({
                icon: 'error',
                title: 'เกิดข้อผิดพลาด',
                footer: 'หรือติดต่อเจ้าหน้าที่'
              });
            }
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
                this.$router.push({
                  name: 'book'
                })
            });
          }).catch(err => {
            this.loadingActive = false
            if(err.response){
              if(err.response.status == 401){
                this.$swal({
                  icon: 'error',
                  title: 'ไม่สามารถทำรายการได้',
                  text: 'ผู้ใช้งานต้องทำการพิสูจน์ตัวตนก่อน'
                });
              }else{
                this.$swal({
                  icon: 'error',
                  title: 'ไม่สามารถทำรายการได้',
                  text: ''
                });
              }
            }else{
              this.$swal({
                icon: 'error',
                title: 'เกิดข้อผิดพลาด',
                footer: 'หรือติดต่อเจ้าหน้าที่'
              });
            }
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
          name: 'book'
        })
      }
    },
    computed: {
      ...mapGetters({
        data: "book/data",
        obj: "book/getObj"
      }),
      name: {
        get() {
          return this.obj.name
        },
        set(data) {
          var key = "name"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      detail: {
        get() {
          return this.obj.detail
        },
        set(data) {
          var key = "detail"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      author: {
        get() {
          return this.obj.author
        },
        set(data) {
          var key = "author"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      publisher: {
        get() {
          return this.obj.publisher
        },
        set(data) {
          var key = "publisher"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      book_category_id: {
        get() {
          return this.obj.book_category_id
        },
        set(data) {
          var key = "book_category_id"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      number_of_page: {
        get() {
          return this.obj.number_of_page
        },
        set(data) {
          var key = "number_of_page"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      image: {
        get() {
          return this.obj.image
        },
        set(data) {
          var key = "image"
          this.$store.commit('book/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
    },
    watch: {
      data: function(val){ 
        if(this.$route.params.action.toLowerCase() == "update"){
          var obj = val.find(x=>x.book_id == this.$route.params.id)
          this.updateObj(obj)
        }
      },
    },
  }
</script>