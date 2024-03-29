# Finance.Tenor
- The best and fast implementation of the finance tenor.
- Low GC Gen0 memory pressure when parsing millions tenors. 


#### Version 3.0.0
- Add support comparison operators "<" ">" "==" "!=" ">=" "<=".
- Supported 1y == 12m 
- Supported 1m == 30d 
- Supported 1w == 7d 

#### Version 3.0.0
 - NetStandard 2.0
 - NetStandard 2.1

 ## Nuget.org

- Nuget package can be downloaded from [Finance.Tenor](https://www.nuget.org/packages/Finance.Tenor/)

## Tenor

[Tenor](https://www.investopedia.com/terms/t/tenor.asp) in finance can have multiple usages, but it most commonly refers to the amount of time left for the repayment 
of a loan or until a financial contract expires. It is most commonly used for non - standardized contracts, such as foreign 
exchange and interest rate swaps, while the term "maturity" is usually used to express the same concept for government bonds and corporate bonds. 
Tenor can also refer to the payment frequency on an interest rate swap.

**DateTime & DateTimeOffset Extension

Code usage examples:

``` c#
    // Create  tenor "1y1m1w1d"
    Tenor tenor = new Tenor(1, 1, 1, 1);
    var dateTime = DateTime.UtcNow;
    dateTime = dateTime + tenor;
     // or 
    dateTime = dateTime - tenor;

```


**The tenor string can be in the following formats:**

- Xd = X day;
- Yw = Y week
- Ym = Z month
- Gy = G year
- or any combinations of above

***Examples:***
- 1w6d
- 1y6m
- 1w1d
- 1y6m2d5w

Code usage examples:

``` c#
    // Create  tenor "1y1m1w1d"
    Tenor tenor = new Tenor(1, 1, 1, 1);
```

``` c#
    // Parse  tenor 
    string tenor = "1m1w1d1y";
    Tenor res =Tenor.Parse(tenor);
```

``` c#
    // Compare  tenors 
    string tenor1w = "1w";
    string tenor7d = "7d";
    Tenor t1w =Tenor.Parse(tenor1w);
    Tenor t7d =Tenor.Parse(tenor7d);

    if( t1w == 7d)
    {
    
    }

```

