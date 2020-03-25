<template>
  <layout>
    <div class="container">
      <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
      <b-row>
        <div class="mb-2 col-12 col-sm col-md">
          <b-card text-variant="white" 
            style="background: linear-gradient(90deg, rgba(42,134,218,1) 0%, rgba(87,178,196,1) 100%);">
            <b-row>
              <div class="col">
                <i class="fas fa-user fa-3x"></i>
                <b-card-text>
                  จำนวนสมาชิก
                </b-card-text>
              </div>
              <div class="col" style="align-self: center;">
                <b-card-text style="font-size:26px;">
                  {{countMember}} คน
                </b-card-text>
              </div>
            </b-row>
            
          </b-card>
        </div>
        <div class="mb-2 col-12 col-sm col-md">
          <b-card text-variant="white" 
            style="background: linear-gradient(90deg, rgba(42,218,127,1) 0%, rgba(76,232,151,1) 100%);">
            <b-row>
              <div class="col">
                <i class="fas fa-book fa-3x"></i>
                <b-card-text>
                  จำนวนหนังสือ
                </b-card-text>
              </div>
              <div class="col" style="align-self: center;">
                <b-card-text style="font-size:26px;">
                  {{countBook}} เล่ม
                </b-card-text>
              </div>
            </b-row>
            
          </b-card>
        </div>
        <div class="mb-2 col-12 col-sm col-md">
          <b-card text-variant="white" 
            style="background: linear-gradient(90deg, rgba(224,112,197,1) 0%, rgba(249,152,225,1) 100%);">
            <b-row>
              <div class="col">
                <i class="fas fa-book-reader fa-3x"></i>
                <b-card-text>
                  ยืมหนังสือ
                </b-card-text>
              </div>
              <div class="col" style="align-self: center;">
                <b-card-text style="font-size:26px;">
                  0 รายการ
                </b-card-text>
              </div>
            </b-row>
            
          </b-card>
        </div>
      </b-row>
    </div>
  </layout>
</template>

<script>
  import { mapActions , mapGetters } from "vuex";
  import layout from '../components/layout'
  export default {
    components: {
      layout
    },
    data() {
      return {
        loadingActive: false,
        countMember: "0",
        countBook: "0"  
      }
    },
    async created() {
      this.loadingActive = true
      await this.$axios.get('/api/Member/GetMemberOnly')
        .then(res => {
          this.countMember = res.data.length.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
          this.loadingActive = false
        })
        .catch(err => {
            console.log('err:' , err);
            this.loadingActive = false
        });
        await this.$axios.get('/api/Book')
        .then(res => {
          this.countBook = res.data.length.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
          this.loadingActive = false
        })
        .catch(err => {
            console.log('err:' , err);
            this.loadingActive = false
        });
    },
    mounted(){

    },
  }
</script>