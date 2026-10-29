# GitHub Copilot Instructions for Bargain Tweaks (Continued) Mod

## Mod Overview and Purpose
Bargain Tweaks (Continued) is a RimWorld mod that updates the original Sladkis mod. This mod enhances the trading system by making traders prefer certain goods over others. Each item has a random price multiplier within a configurable range of 0.6 to 1.4. Additionally, the mod introduces an advanced mode that allows for more detailed customization of how bargain prices are calculated.

## Key Features and Systems
### Price Modifiers
- Each item has a random price multiplier between 0.6 and 1.4.
- Advanced mode allows customization of price calculation based on the difference between buying and selling prices.

### Trading System
- The mod ensures that pawns with lower negotiation skills do not sell items for higher prices than those with higher negotiation skills.
- The effect of trader type modifiers and trader demand modifiers is configurable and dependent on the trader type modifier.

### Compatibility
- Compatible with other mods that do not change the trading screen.
- Does not require a new save and can be safely deleted from existing saves.

## Coding Patterns and Conventions
- **Namespace**: All classes are located within the `BargainTweaks` namespace.
- **Harmony Patches**: Harmony patches are used to modify vanilla RimWorld methods.
- **XML Integration**: XML files are used for configuration and mod metadata.

## XML Integration
- **About.xml**: Contains metadata about the mod, including dependencies.
- **Manifest.xml**: Contains basic mod information.
- **ModSync.xml**: Used for synchronization purposes, if applicable.

### Example XML File: About.xml
xml
<About>
    <ModIdentifier>Mlie.BargainTweaks</ModIdentifier>
    <Name>Bargain Tweaks (Continued)</Name>
    <Author>Sladki</Author>
    <Version>1.0.0</Version>
    <Description>Update of Sladkis mod. Small mod that makes traders prefer some goods over other: every item has random price multiplier in range 0.6-1.4 (configurable).</Description>
    <Dependencies>
        <Dependency>
            <ModIdentifier>brrainz.harmony</ModIdentifier>
            <MinimumVersion>1.0.0</MinimumVersion>
        </Dependency>
    </Dependencies>
</About>


## Harmony Patching
Harmony patches are used to modify vanilla RimWorld methods. The following are some examples of Harmony patches used in this mod:

### Example Harmony Patch: TradeUI_DrawTradeableRow.cs
csharp
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace BargainTweaks.Trading.Patches
{
    [HarmonyPatch(typeof(TradeUI), "DrawTradeableRow")]
    public static class TradeUI_DrawTradeableRow
    {
        public static void Postfix(Tradeable tradeable)
        {
            // Custom logic to modify the trading UI
            var bargainPrice = new BargainBasePrice(tradeable);
            var priceText = bargainPrice.Value.ToString("F0");
            Widgets.Label(new Rect(100, 0, 200, 30), priceText);
        }
    }
}


## Suggestions for Copilot
- **Mod Compatibility**: Ensure that the mod remains compatible with other trading-related mods.
- **Error Handling**: Add robust error handling for unexpected situations during price calculations.
- **Configuration**: Provide more configuration options for advanced users to fine-tune the price modifiers.
- **Logging**: Implement logging to help with debugging and troubleshooting.

## Contributing
- **Code Contributions**: Contributions to the codebase are welcome. Please ensure that any changes adhere to the coding patterns and conventions outlined above.
- **Reporting Issues**: If you encounter any issues, please report them using the Discord channel for error reporting. Include logs using the Log Uploader.

## Contact
- **Author**: Sladki
- **Discord**: [Discord Channel](https://discord.gg/your-discord-channel)
- **Email**: [Your Email Address](mailto:your-email@example.com)



This .github/copilot-instructions.md file provides a comprehensive guide for contributors and developers working on the Bargain Tweaks (Continued) mod, covering key features, coding conventions, XML integration, Harmony patching, and suggestions for using GitHub Copilot.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

