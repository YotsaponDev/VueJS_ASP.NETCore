<template>
  <div class="container">
    <b-card title="ลงทะเบียน">
      <b-card-text>
        <b-row>
          <b-col sm="6" class="mb-2 mb-sm-3">
            <b-form inline class="float-sm-right">
              <label class="mr-sm-2">ชื่อ</label>
              <b-form-input v-model="firstname" type="text"></b-form-input>
            </b-form>
          </b-col>
          <b-col sm="6" class="mb-2 mb-sm-3">
            <b-form inline>
              <label class="mr-sm-2">นามสกุล</label>
              <b-form-input type="text"></b-form-input>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-1 mb-sm-2">
            <b-form inline class="justify-content-sm-center">
              <label class="mr-sm-2">วัน/เดือน/ปี เกิด</label>
              <b-form-input type="date"></b-form-input>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-sm-3 mb-2">
            <b-form inline class="justify-content-sm-center">
              <label class="mr-sm-2 mr-2 mt-3 mt-sm-2">เพศ</label>
              <b-form-radio-group :options="[ { item: 'M', name: 'ชาย' }, { item: 'F', name: 'หญิง' }]" class="mt-2"
                value-field="item" text-field="name"></b-form-radio-group>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-2 mb-sm-3">
            <b-form inline class="justify-content-sm-center">
              <label style="margin-right: 72px;">อีเมล</label>
              <b-form-input type="email"></b-form-input>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-2 mb-sm-3">
            <b-form inline class="justify-content-sm-center">
              <label style="margin-right: 47px;">รหัสผ่าน</label>
              <b-form-input type="password"></b-form-input>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-2 mb-sm-3">
            <b-form inline class="justify-content-sm-center">
              <label class="mr-sm-2">ยืนยันรหัสผ่าน</label>
              <b-form-input type="password"></b-form-input>
            </b-form>
          </b-col>
        </b-row>
        <b-row>
          <b-col class="mb-2 mb-sm-3">
            <b-form inline class="justify-content-center">
              <b-button class="mr-2" variant="success">ลงทะเบียน</b-button>
              <b-button variant="danger">ยกเลิก</b-button>
            </b-form>
          </b-col>
        </b-row>
      </b-card-text>
    </b-card>
  </div>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  export default {
    computed: {
       firstname: {
        get () {
          // return this.$store.state.obj.message
        },
        set (data) {
          var key = "firstname"
          this.$store.commit('register/UPDATE_OBJ_BY_KEY', {key,data})
        }
      },
      ...mapGetters({

      }),
    }
  }
</script>