# santa-api
Remarks:
- The list of children is persistent and cannot be modified by the current endpoints, as well as the list of gifts, as was required in the requirements.
  The endpoints allow chnages in the ownership of a child over gifts.
- I used sqlite for simplicity sake rather than MSSQL.
- The sqlite db file, santa.db, is in the project folder and can be easily expored using a simple sqlite db browser such as the one in https://sqlitebrowser.org/.
- Unfortunately I didn't have enough time to write unit tests. However, I'd create tests for the methods in the GiftsService and mock its dependencies using Moq library.


- "~ 50 gift request per second".
.NET runtime handle the allocation of a new thread for its thread pool per web request.

- "Santa cannot spend > 50 coins for one child and will try to send the most expensive gifts first.".
Just assumed there will be another service that will handle the dispatch for the actual sending of the gifts. The current functionality registers who asked for what and in which color.
