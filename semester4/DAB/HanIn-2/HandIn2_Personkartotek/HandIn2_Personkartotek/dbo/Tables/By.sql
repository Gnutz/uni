CREATE TABLE [By] (
  [ByID] uint,
  [Bynavn] string,
  [PostNr] string,
  [Land] LandID,
  PRIMARY KEY ([ByID])
);
GO
CREATE INDEX [FK] ON  [By] ([Land]);