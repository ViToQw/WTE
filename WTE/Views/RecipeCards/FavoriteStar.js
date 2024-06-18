const FavoriteStar = {
    template: `
    <div @click="toggleFavorite" class="favorite-star">
        <svg v-if="isFavorite"
             xmlns="http://www.w3.org/2000/svg"
             fill="red"
             viewBox="0 0 24 24"
             stroke="currentColor"
             class="heart-icon">
            <path stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M5 13l4 4L19 7M5 13V7h12" />
        </svg>
        <svg v-else
             xmlns="http://www.w3.org/2000/svg"
             fill="none"
             viewBox="0 0 24 24"
             stroke="currentColor"
             class="heart-icon">
            <path stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M5 13l4 4L19 7M5 13V7h12" />
        </svg>
    </div>
  `,
    props: {
        recipeId: {
            type: Number,
            required: true,
        },
        isFavorite: {
            type: Boolean,
            default: false,
        },
        userId: {
            type: Number,
            required: true,
        },
    },
    methods: {
        toggleFavorite() {
            const url = `http://hnt8.ru:8222/favorites/${this.userId}/recipes/${this.recipeId}`;
            if (this.isFavorite) {
                axios.delete(url).then(response => {
                    console.log('Рецепт удален из избранного:', response.data);
                });
            } else {
                axios.post(url).then(response => {
                    console.log('Рецепт добавлен в избранное:', response.data);
                });
            }
            this.isFavorite = !this.isFavorite;
        },
    },
};

