<template>
    <div>
        <div style="text-align: center; margin-top: 50px;" v-if="isLoadingDone">
        Redirecting...
        </div>
        <div v-else>
            <textarea ref="text" class="container-text-area" readonly></textarea>
        </div>
    </div>
</template>
<script setup lang="ts">
    import router from '@/router';
    import { getCurrentInstance, onMounted, ref } from 'vue';
    import { useRoute } from 'vue-router';
    const API_URL = getCurrentInstance()?.appContext.config.globalProperties.API_URL
    let isLoadingDone = false
    const route = useRoute()
    let text = ref()
    const url = new URL(API_URL)
    url.searchParams.set('code', route.params.code as string)

    fetch(url.toString())
    .then((data) => data.json())
    .then((data) => {
        if(data.text) {
            text.value.innerHTML = data.text
            isLoadingDone = true
        } else {
            throw Error()
        }
    })
    .catch(() => {
        router.push({ name: 'home' })
    })
</script>