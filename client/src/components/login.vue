<style>
    /* .vertical-center {
        margin: 0;
        position: absolute;
        top: 50%;
        left: 50%;
        -ms-transform: translate(-50%, -50%);
        transform: translate(-50%, -50%);
    } */
</style>
<template>
    <div class="container">
        <div class="vertical-center mt-3 mb-3">
            <b-card title="เข้าสู่ระบบ" body-class="text-center" header-tag="nav">
                <template v-slot:header>
                    <b-nav card-header tabs>
                        <b-nav-item to="/login" exact exact-active-class="active">เข้าสู่ระบบ</b-nav-item>
                        <b-nav-item to="/register">ลงทะเบียน</b-nav-item>
                    </b-nav>
                </template>

                <b-img :src="require('../assets/image/b.png')" fluid alt="Responsive image" width="100" height="100">
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
                <b-button variant="primary">เข้าสู่ระบบ</b-button>
            </b-card>
        </div>
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

            }
        },
        mounted() {
            console.log(this.$axios);

            this.$axios.get('/api/Member')
                .then((resp) => {
                    console.log(resp);
                })
                .catch(() => {
                    console.log('err:', err);
                });
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