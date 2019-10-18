# EntityFramewrokCoreExtension
The extension function for entity framework core.
## Features
### Entity Extension
#### * Supply Guid Primary Key if it's Empty
##### Usage

```c#
public class Token{
    public virtual Guid Id { get; set; }
}
```

```c#
[HttpPost]
public async Task<IActionResult> Post(Token token)
{
    //token.Id=Guid.Empty
    token = token.SupplyGuidKeyIfEmpty(_dbContext.Model);
    // now token.Id is new guid.
    _dbContext.Tokens.Add(token);
    if (await _dbContext.SaveChangesAsync() > 0)
    {
        return Ok(token.Id);
    }
    return BadRequest();
}
```