# Property Normaliser

A small full-stack project consisting of:

- Backend API: .NET 8 Web API with Entity Framework Core.
- Frontend UI: React 18 + TypeScript + Vite + TailwindCSS.
- Includes basic unit tests (xUnit for API, Vitest/RTL for UI).

## How to run

### Backend (API)

```bash
cd PropertyNormalizer.API
dotnet restore
dotnet build
dotnet run
```

### Run tests:

```bash
cd PropertyNormalizer.Tests
dotnet test
```

### Run API with Docker

1. Make sure you are in the root of the solution:

```bash
cd PropertyNormalizer
```

2. Build the image:

```bash
docker build -t property-normalizer-api -f PropertyNormalizer.API/Dockerfile .
```

3. Run the container:

```bash
docker run -d -p 8080:8080 --name property-api property-normalizer-api
```

4. Access the API:

```bash
Swagger UI: http://localhost:8080/swagger
```

### Frontend (UI)

```bash
cd PropertyNormalizerClient
npm install
npm run dev
```

### Run tests:

```bash
npm run test
```

### Time spent

- ~4h hours total
- 2h backend (API, repo, services, unit tests)
- 1h 30m frontend (UI, modal with validation, RTL tests)
- 30m Sql Queries

### Assumptions

- API persistence: Implemented with an in-memory repository instead of a real database, for simplicity.
- Frontend validation: Limited to the numeric rules defined in the task (Volume = 1–6 digits, Folio = 1–5 digits).
- UI accessibility was implemented only with focus trap and Escape key dismissal for the modal.

### Approach & trade-offs

- Focused on core functionality first (normalize service, CRUD, modal UX).
- Tests written only for core paths + edge validation (not full coverage).
- Simplified styling with Tailwind (no complex design system).=

### AI Assistance

- Used ChatGPT (OpenAI GPT-5) for:
  - Generating basic HTML and CSS.
  - Creating sample SQL data.
  - Producing mock data for testing.
  - Quick lookups and clarifications.
