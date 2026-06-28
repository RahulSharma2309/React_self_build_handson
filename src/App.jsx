import { useState } from 'react'
import './App.css'
import { ProductCard } from './components/ProductCard.jsx'
import { fallbackProducts } from './data/fallbackProducts.js'

function App() {
  const [searchTerm, setSearchTerm] = useState('')
  const [selectedCategory, setSelectedCategory] = useState('All')
  const [sortBy, setSortBy] = useState('featured')

  const categories = ['All', ...new Set(fallbackProducts.map((product) => product.category))]

  const normalizedSearchTerm = searchTerm.trim().toLowerCase()

  const visibleProducts = fallbackProducts
    .filter((product) => {
      const matchesSearch =
        product.name.toLowerCase().includes(normalizedSearchTerm) ||
        product.summary.toLowerCase().includes(normalizedSearchTerm)
      const matchesCategory = selectedCategory === 'All' || product.category === selectedCategory

      return matchesSearch && matchesCategory
    })
    .sort((firstProduct, secondProduct) => {
      if (sortBy === 'price-low') {
        return firstProduct.price - secondProduct.price
      }

      if (sortBy === 'price-high') {
        return secondProduct.price - firstProduct.price
      }

      return firstProduct.id - secondProduct.id
    })

  return (
    <div className="app">
      <header className="hero">
        <p className="eyebrow">Story 03</p>
        <h1>VoltShop Starter Catalog</h1>
        <p>
          Search, filter, and sort these local products. The controls update
          React state, and the product grid is recalculated from that state.
        </p>
      </header>

      <section className="catalog-controls" aria-label="Product filters">
        <label className="control">
          <span>Search products</span>
          <input
            type="search"
            value={searchTerm}
            onChange={(event) => setSearchTerm(event.target.value)}
            placeholder="Try robot or pi"
          />
        </label>

        <label className="control">
          <span>Category</span>
          <select
            value={selectedCategory}
            onChange={(event) => setSelectedCategory(event.target.value)}
          >
            {categories.map((category) => (
              <option key={category} value={category}>
                {category}
              </option>
            ))}
          </select>
        </label>

        <label className="control">
          <span>Sort by</span>
          <select value={sortBy} onChange={(event) => setSortBy(event.target.value)}>
            <option value="featured">Featured</option>
            <option value="price-low">Price: low to high</option>
            <option value="price-high">Price: high to low</option>
          </select>
        </label>
      </section>

      {visibleProducts.length > 0 ? (
        <section className="product-grid" aria-label="Product catalog">
          {visibleProducts.map((product) => (
            <ProductCard key={product.id} product={product} />
          ))}
        </section>
      ) : (
        <p className="empty-state">No products match your filters. Try a different search.</p>
      )}
    </div>
  )
}

export default App
