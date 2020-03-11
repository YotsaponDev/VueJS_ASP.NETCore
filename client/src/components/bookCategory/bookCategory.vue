<template>
  <layout>
    <div class="container">
      <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
      <b-card title="จัดการหมวดหมู่หนังสือ" body-class="text-center">
        <b-row>
          <div class="col col-sm-6 col-md-5 col-lg-5 col-xl-4 mb-2">
            <b-form-group
              label="ค้นหา"
              label-cols-sm="3"
              label-align-sm="right"
              label-size="sm"
              label-for="filterInput"
              class="mb-0"
            >
            <b-input-group size="sm">
              <b-form-input
                v-model="filter"
                type="search"
                id="filterInput"
                placeholder="ค้นหา"
              ></b-form-input>
              <b-input-group-append>
                <b-button :disabled="!filter" @click="filter = ''">ยกเลิก</b-button>
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
          
          </div>
          <div class="col-sm col-md col-lg col-xl text-right mb-2">
            <b-button variant="primary" size="md" @click="addEvent()"><i class="fas fa-plus"></i> เพิ่มรายการ</b-button>
          </div> 
        </b-row>
        <b-table 
          responsive
          :filter="filter"
          :items="data" 
          :fields="header" 
          :current-page="currentPage"
          :per-page="perPage">
        </b-table>
        <b-row>
          <div class="col-sm col-md col-lg col-xl">
          </div>
          <div class="col col-sm-5 col-md-4 col-lg-4 col-xl-3">
            <b-pagination
              v-model="currentPage"
              :total-rows="totalRows"
              :per-page="perPage"
              align="fill"
              size="sm"
              class="my-0">
            </b-pagination>
          </div>
        </b-row>
        
      </b-card>
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
        header: [{
            key: "code",
            sortable: true,
            label: "รหัสหมวดหมู่"
          },{
            key: "name",
            sortable: true,
            label: "ชื่อหมวดหมู่"
          }
        ],
        totalRows: 0,
        currentPage: 1,
        perPage: 5,
        filter: null,
        loadingActive: false
      }
    },
    created() {
      this.loadingActive = true
      this.initData().then(res => {
            this.loadingActive = false
      }).catch(err=>{
        this.loadingActive = false
      })
    },
    mounted(){
      
    },
    methods: {
      ...mapActions("book_category", ["initData"]),
      addEvent(){
        this.$router.push({ name: "book_category_d", params: { id: "_", action: "create" } });
      }
    },
    computed: {
      ...mapGetters({
        data: "book_category/data"
      }),
    },
    watch: {
      data: function(val){
        this.totalRows = val.length
      }
    },
  }
</script>