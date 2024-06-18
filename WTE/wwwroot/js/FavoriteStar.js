const FavoriteStar = {
    props: {
        recipeId: {
            type: Number,
            required: true,
        },
        isFavorite: {
            type: Boolean,
            required: true,
        },
        userId: {
            type: Number,
            required: true,
        },
    },
    template: `
    <div @click="toggleFavorite" class="favorite-star">
      <img v-bind:src="heartIconSrc" class="heart-icon" />
    </div>
  `,
    computed: {
        heartIconSrc() {
            return this.isFavorite ? '../Content/Images/icons8-heart-red.png' : '../Content/Images/icons8-heart.png';
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
            this.$emit('update:is-favorite', !this.isFavorite); // Эмитируем событие обновления пропса
        },
    },
    style: `
    .favorite-star {
      cursor: pointer;
      display: inline-block; /* Чтобы размер блока подстраивался под изображение */
    }

    .heart-icon {
      width: 24px;
      height: 24px;
      transition: opacity 0.3s ease; /* Анимация изменения прозрачности */
    }
  `
};



