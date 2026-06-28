export function ProductCard({ product }) {
  return (
    <article className="product-card">
      <img className="product-card__image" src={product.image} alt="" />
      <div className="product-card__body">
        <p className="product-card__category">{product.category}</p>
        <h2 className="product-card__title">{product.name}</h2>
        <p className="product-card__summary">{product.summary}</p>
        <p className="product-card__price">₹{product.price.toLocaleString('en-IN')}</p>
      </div>
    </article>
  )
}
