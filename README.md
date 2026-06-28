# React Building Self

This repo is a blank-slate rebuild of the finished `React Learning` app.

The goal is not to read a finished project and feel lost. The goal is to rebuild the same app slowly, story by story, with your hands on the keyboard.

## Current Shape

- `src/` is intentionally tiny: a Vite React app with one `App` component.
- `backend/` is already lifted from `React Learning`: catalog, orders, and gateway APIs.
- `docs/` contains the progressive build stories.

The backend is supporting cast. React is the main thing you are learning.

## Run The Blank Frontend

```powershell
npm install
npm run dev
```

Open the Vite URL, usually `http://localhost:5173`.

## Run The Backend

Open three terminals from this repo root:

```powershell
.\start-catalog.ps1
.\start-orders.ps1
.\start-gateway.ps1
```

Ports:

- Frontend: `http://localhost:5173`
- Gateway: `http://localhost:5100`
- Catalog service: `http://localhost:5201`
- Orders service: `http://localhost:5202`

## How To Learn From This Repo

Start at `docs/README.md`, then follow the stories in `docs/stories/` in order.

Each story tells you:

- what feature you are building,
- which React concept it teaches,
- which files to create or edit,
- what to test in the browser,
- where to compare with the finished `React Learning` app when you want a reference.
