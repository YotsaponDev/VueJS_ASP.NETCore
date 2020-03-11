<template>
  <div class="container">
    <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
    <ValidationObserver v-slot="{ handleSubmit }">
      <div class="mt-3 mb-3">
        <b-card title="ลงทะเบียน" header-tag="nav">
          <template v-slot:header>
            <b-nav card-header tabs>
              <b-nav-item to="/login">เข้าสู่ระบบ</b-nav-item>
              <b-nav-item to="/register" exact exact-active-class="active">ลงทะเบียน</b-nav-item>
            </b-nav>
          </template>
          <b-card-text>
            <b-row>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider class="float-sm-right" name="ชื่อ" v-slot="{ errors }" rules="required">
                  <b-form inline>
                    <label class="mr-sm-2">ชื่อ</label>
                    <b-form-input v-model="firstname" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
              <b-col sm="6" class="mb-2 mb-sm-3">
                <ValidationProvider name="นามสกุล" class="float-sm-left" v-slot="{ errors }" rules="required">
                  <b-form inline>
                    <label class="mr-sm-2">นามสกุล</label>
                    <b-form-input v-model="lastname" type="text"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-1 mb-sm-2">
                <ValidationProvider name="วัน/เดือน/ปี เกิด" v-slot="{ errors }" rules="required">
                  <b-form inline class="justify-content-sm-center">
                    <label class="mr-sm-2">วัน/เดือน/ปี เกิด</label>
                    <b-form-input v-model="birthday" type="date"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-sm-3 mb-2">
                <ValidationProvider name="เพศ" v-slot="{ errors }" rules="required">
                  <b-form inline class="justify-content-sm-center">
                    <label class="mr-sm-2 mr-2 mt-3 mt-sm-2">เพศ</label>
                    <b-form-radio-group :options="[ { item: 'M', name: 'ชาย' }, { item: 'F', name: 'หญิง' }]"
                      class="mt-2" value-field="item" v-model="sex" text-field="name"></b-form-radio-group>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-2 mb-sm-3">
                <ValidationProvider name="อีเมล" v-slot="{ errors }" rules="required|email">
                  <b-form inline class="justify-content-sm-center">
                    <label style="margin-right: 72px;">อีเมล</label>
                    <b-form-input v-model="email" type="email"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-2 mb-sm-3">
                <ValidationProvider name="รหัสผ่าน" v-slot="{ errors }" rules="required|min:8" vid="passwordConfirmed">
                  <b-form inline class="justify-content-sm-center">
                    <label style="margin-right: 47px;">รหัสผ่าน</label>
                    <b-form-input v-model="tempPassword" type="password"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-2 mb-sm-3">
                <ValidationProvider name="รหัสผ่าน" v-slot="{ errors }" rules="required|confirmed:passwordConfirmed">
                  <b-form inline class="justify-content-sm-center">
                    <label class="mr-sm-2">ยืนยันรหัสผ่าน</label>
                    <b-form-input v-model="password" type="password"></b-form-input>
                  </b-form>
                  <span id="errorValidate">{{ errors[0] }}</span>
                </ValidationProvider>
              </b-col>
            </b-row>
            <b-row>
              <b-col class="mb-2 mb-sm-3">
                <b-form inline class="justify-content-center">
                  <b-button class="mr-2" @click.prevent="handleSubmit(register)" variant="success">ลงทะเบียน
                  </b-button>
                  <b-button variant="danger">ยกเลิก</b-button>
                </b-form>
              </b-col>
            </b-row>
          </b-card-text>
        </b-card>
      </div>
    </ValidationObserver>
  </div>
</template>

<script>
  import {
    mapActions,
    mapGetters
  } from "vuex";
  export default {
    data() {
      return {
        tempPassword: null,
        loadingActive: false
      }
    },
    methods: {
      ...mapActions("register", ["postData"]),
      register() {
        this.loadingActive = true
        this.postData().then(res => {
          this.loadingActive = false
          this.$swal({
            icon: 'success',
            title: 'ลงทะเบียนสำเร็จ',
            showConfirmButton: false,
            timer: 3200
          });
        }).catch(err => {
          console.log(err);
          
          this.loadingActive = false
          this.$swal({
            icon: 'error',
            title: 'เกิดข้อผิดพลาด',
            text: err.response.data,
            footer: 'หรือติดต่อเจ้าหน้าที่'
          });
        })
      }
    },
    computed: {
      firstname: {
        get() {
          return this.obj.firstname
        },
        set(data) {
          var key = "firstname"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      lastname: {
        get() {
          return this.obj.lastname
        },
        set(data) {
          var key = "lastname"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      birthday: {
        get() {
          return this.obj.birthday
        },
        set(data) {
          var key = "birthday"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      sex: {
        get() {
          return this.obj.sex
        },
        set(data) {
          var key = "sex"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      email: {
        get() {
          return this.obj.email
        },
        set(data) {
          var key = "email"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      password: {
        get() {
          return this.obj.password
        },
        set(data) {
          var key = "password"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {
            key,
            data
          })
        }
      },
      ...mapGetters({
        obj: "register/getObj"
      }),
    }
  }
</script>