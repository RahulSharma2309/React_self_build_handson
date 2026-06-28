import './App.css'
import { ProductCard } from './components/ProductCard.jsx'
import { fallbackProducts } from './data/fallbackProducts.js'

function App() {
  return (
    <div className="app">
      <header className="hero">
        <p className="eyebrow">Story 02</p>
        <h1>VoltShop Starter Catalog</h1>
        <p>
          These cards are rendered from local JavaScript data. Change
          `fallbackProducts` and the screen changes with it.
        </p>
      </header>

      <section className="product-grid" aria-label="Product catalog">
        {fallbackProducts.map((product) => (
          <ProductCard key={product.id} product={product} />
        ))}
      </section>
    </div>
  )
}

export default App
