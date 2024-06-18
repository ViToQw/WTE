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
       <img v-bind:src="heartIconSrc" class="heart-icon" :class="{ 'is-favorite': isFavorite }" />
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
                this.$emit('update:is-favorite', false);
            } else {
                axios.post(url).then(response => {
                    console.log('Рецепт добавлен в избранное:', response.data);
                    this.$emit('update:is-favorite', true);
                });
            }
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
  transition: transform 0.3s ease, filter 0.3s ease, opacity 0.3s ease; /* Анимация изменения прозрачности, фильтра и трансформации */
}

.heart-icon:hover {
  transform: scale(1.2) rotate(20deg); /* Увеличение размера и поворот при наведении */
  opacity: 0.8; /* Изменение прозрачности при наведении */
}

.is-favorite {
  filter: hue-rotate(330deg) brightness(1.2); /* Изменение цвета на красный и увеличение яркости для избранного */
}
  `
};



