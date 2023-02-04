# santa-api
Remarks:
- The list of children is persistent and cannot be modified by the current endpoints, as well as the list of gifts, as was required in the requirements.
  The endpoints allow chnages in the ownership of a child over gifts.
- I used sqlite for simplicity sake rather than MSSQL.
- The sqlite db file, santa.db, is in the project folder and can be easily expored using a simple sqlite db browser such as the one in https://sqlitebrowser.org/.
- Unfortunately I didn't have enough time to write unit tests. However, I'd create tests for the methods in the GiftsService and mock its dependencies using Moq library.
