using System.Diagnostics;
using LibGit2Sharp;

var url = "file://path/to/repository";

// Clone
var directory = Directory.CreateDirectory(Path.Join(Directory.GetCurrentDirectory(), "test-git-clone", $"{Guid.NewGuid()}")).FullName;

var sw = Stopwatch.StartNew();
var clonedRepoPath = Repository.Clone(url, directory);
Console.WriteLine($"Clone: {sw.ElapsedMilliseconds}ms");

var repo = new Repository(clonedRepoPath);
var remote = repo.Network.Remotes.Single();

// Fetch
sw.Restart();
repo.Network.Fetch(remote.Name, remote.FetchRefSpecs.Select(spec => spec.Specification));
Console.WriteLine($"Fetch: {sw.ElapsedMilliseconds}ms");

// List references
sw.Restart();
Repository.ListRemoteReferences(url);
Console.WriteLine($"List References: {sw.ElapsedMilliseconds}ms");

// Commit Empty
sw.Restart();
repo.Commit(
    "Commit message for empty commit",
    new Signature("Test", "test@test.com", DateTimeOffset.Now),
    new Signature("Test", "test@test.com", DateTimeOffset.Now),
    new CommitOptions { AllowEmptyCommit = true }
);
Console.WriteLine($"Commit empty: {sw.ElapsedMilliseconds}ms");

// Push Empty
sw.Restart();
repo.Network.Push(repo.Head);
Console.WriteLine($"Push empty: {sw.ElapsedMilliseconds}ms");