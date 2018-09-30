CREATE TABLE [Adresse] (
  [AdresseID] uint,
  [Vejnavn] string,
  [HusNr] uint,
  [By] ByID,
  PRIMARY KEY ([AdresseID])
);
GO
CREATE INDEX [FK] ON  [Adresse] ([By]);