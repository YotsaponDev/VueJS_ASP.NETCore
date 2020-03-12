<template>
  <layout>
    <div class="container">
      <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
      <b-row>
        <div class="mb-2 col-12 col-sm col-md">
          <b-card text-variant="white" style="background: linear-gradient(90deg, rgba(42,134,218,1) 0%, rgba(87,178,196,1) 100%);">
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
          <b-card bg-variant="success" text-variant="white" >
            <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
          </b-card>
        </div>
        <div class="mb-2 col-12 col-sm col-md">
          <b-card bg-variant="success" text-variant="white">
            <b-card-text>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</b-card-text>
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
        countMember: "0"  
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
    },
    mounted(){

    },
  }
</script>