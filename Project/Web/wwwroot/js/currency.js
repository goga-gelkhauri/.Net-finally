var app = new Vue({
    el: '#app',
    data: {
        currencies: [],
        selectedCurrency: null
    },
    mounted() {
        this.getCurrency();
    },
    methods: {
        getCurrency() {
            this.loading = true;
            axios.get('/api/Apicurrency')
                .then(res => {
                    this.currencies = res.data;
                    console.log(this.currencies);
                }).catch(err => {
                    console.log(err);
                }).then(() => {
                    this.loading = false;
                });
        }
        
    }
});