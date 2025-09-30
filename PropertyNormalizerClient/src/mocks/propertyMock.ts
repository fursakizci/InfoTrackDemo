import type { InternalProperty } from "../types/property";

export const MOCK_PROPERTY: InternalProperty = {
  fullAddress: "10 Example St, Carlton VIC 3053",
  lotPlan: { lot: "12", plan: "PS123456" },
  volumeFolio: { volume: null, folio: null },
  status: "UnknownVolFol",
  sourceTrace: {
    provider: "VIC-DDP",
    requestId: "REQ-12345",
    receivedAt: "2025-08-30T03:12:45Z",
  },
};
