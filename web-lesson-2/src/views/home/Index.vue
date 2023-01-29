<template>
    <h1>Hi {{  username }}, your password is {{ password  }}! </h1>
</template>

<script lang="ts">

var user = {
    username: "admin",
    password: "sa"
};

export default {
    name: "Home",
    data() {
        return {
            username: "",
            password: "",
        };
    },
    mounted () {
        fetch("https://localhost:7139/user/login", 
        {
            method: "POST",
            mode: "cors",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(user),
        })
        .then((res) => res.json())
        .then((data) => {
            console.log('Success:', data);
            this.username = data.username;
            this.password = data.password;
        });
    },
};

</script>