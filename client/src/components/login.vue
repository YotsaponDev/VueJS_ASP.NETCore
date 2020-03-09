<style>
    #errorValidate {
        color: red;
        font-size: 10pt;
    }
</style>
<template>
    <div class="container">
        <Loading spinner="line-wave" size="50" :active="loadingActive" :is-full-screen="true" color="#0099ff" />
        <ValidationObserver v-slot="{ handleSubmit }">
            <div class="mt-3 mb-3">
                <b-card title="เข้าสู่ระบบ" body-class="text-center" header-tag="nav">
                    <template v-slot:header>
                        <b-nav card-header tabs>
                            <b-nav-item to="/login" exact exact-active-class="active">เข้าสู่ระบบ</b-nav-item>
                            <b-nav-item to="/register">ลงทะเบียน</b-nav-item>
                        </b-nav>
                    </template>

                    <b-img :src="require('../assets/image/b.png')" fluid alt="Responsive image" width="100"
                        height="100">
                    </b-img>

                    <b-card-text>
                        <b-row>
                            <b-col class="mb-2 mb-sm-3 mt-2 mt-sm-3">
                                <ValidationProvider name="อีเมล" v-slot="{ errors }" rules="required|email">
                                    <b-form inline class="justify-content-sm-center">
                                        <label style="margin-right: 32px;">อีเมล</label>
                                        <b-form-input v-model="email" type="email"></b-form-input>
                                    </b-form>
                                    <span id="errorValidate">{{ errors[0] }}</span>
                                </ValidationProvider>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col class="mb-2 mb-sm-2">
                                <ValidationProvider name="รหัสผ่าน" v-slot="{ errors }" rules="required|min:8"
                                    vid="passwordConfirmed">
                                    <b-form inline class="justify-content-sm-center">
                                        <label style="margin-right: 7px;">รหัสผ่าน</label>
                                        <b-form-input v-model="password" type="password"></b-form-input>
                                    </b-form>
                                    <span id="errorValidate">{{ errors[0] }}</span>
                                </ValidationProvider>
                            </b-col>
                        </b-row>
                    </b-card-text>
                    <b-button variant="primary" @click.prevent="handleSubmit(loginEvent)">เข้าสู่ระบบ</b-button>
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
    // import loading from './loading'
    export default {
        data() {
            return {
                loadingActive: false
            }
        },
        mounted() {
            var loggedIn = localStorage.getItem('jwt');
            // console.log(Vue.VueElementLoading,"loading");
            

        },
        methods: {
            ...mapActions("login", ["login"]),
            loginEvent() {
                this.loadingActive = true
                this.login().then(res => {
                    this.loadingActive = false
                    this.$router.push({
                        name: 'index'
                    })
                }).catch(err => {
                    this.loadingActive = false
                })
            }
        },
        computed: {
            email: {
                get() {
                    return this.obj.email
                },
                set(data) {
                    var key = "email"
                    this.$store.commit('login/UPDATE_OBJ_BY_KEY', {
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
                    this.$store.commit('login/UPDATE_OBJ_BY_KEY', {
                        key,
                        data
                    })
                }
            },
            ...mapGetters({
                obj: "login/getObj"
            }),
        }
    }
</script>