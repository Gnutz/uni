CREATE TABLE [Person] (
  [PersonID] uint,
  [Prmær Adresse] AdresseID,
  [Fornavn] string,
  [Mellemnavn] string,
  [Efternavn] string,
  [email  adresse] string,
  [Noter] string,
  PRIMARY KEY ([PersonID])
);
GO
CREATE INDEX [FK] ON  [Person] ([Prmær Adresse]);