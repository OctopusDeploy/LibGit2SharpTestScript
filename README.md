# LibGit2Sharp Test Script
A script for testing LibGit2Sharp performance on a local machine. This will write data. Do not use with any repositories that you care about.

To run the script, enter the absolute path to the repository on disk in the URL variable, and run `dotnet run` from the command line.

The path will look something like this:

- On Windows: `file://C:/path/to/repository`
- On Mac/Linux: `file://C:/path/to/repository`

## Result
The output will be written to the console:

```
Clone: 75ms
Fetch: 6ms
List References: 4ms
Commit empty: 35ms
Push empty: 13ms
```