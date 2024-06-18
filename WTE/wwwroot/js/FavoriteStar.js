const FavoriteStar = {
    model: {
        prop: 'isFavorite',
        event: 'update:is-favorite',
    },
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
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24" fill="none" :class="['heart-icon', { 'is-favorite': isFavorite }]">
        <path d="M12 21.35l-1.45-1.32C5.4 15.36 2 12.28 2 8.5 2 5.42 4.42 3 7.5 3c1.74 0 3.41.81 4.5 2.09C13.09 3.81 14.76 3 16.5 3 19.58 3 22 5.42 22 8.5c0 3.78-3.4 6.86-8.55 11.54L12 21.35z"/>
      </svg>
    </div>
  `,
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
      width: 24px;
      height: 24px;
    }

    .heart-icon {
      width: 24px;
      height: 24px;
      transition: fill 0.3s ease; /* Анимация изменения цвета */
    }

    .heart-icon.is-favorite {
      fill: red; /* Цвет сердца в избранном состоянии */
      width: 24px;
      height: 24px;
    }
  `
};

