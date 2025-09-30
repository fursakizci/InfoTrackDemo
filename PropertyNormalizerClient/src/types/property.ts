export type VolumeFolio = {
  volume: string | null;
  folio: string | null;
};

export type LotPlan = {
  lot?: string;
  plan?: string;
};

export type SourceTrace = {
  provider?: string;
  requestId?: string;
  receivedAt?: string;
};

export type InternalProperty = {
  fullAddress: string;
  lotPlan?: LotPlan;
  volumeFolio: VolumeFolio;
  status: "KnownVolFol" | "UnknownVolFol";
  sourceTrace: SourceTrace;
};
