<p align="center">
  <img src="https://cdn.discordapp.com/attachments/1297612591656341504/1297617737081950278/image.png?ex=67169431&is=671542b1&hm=e3c6bfd6c059e17549c7185b80347e86665b3f27139c986d9f8493027fc4a8d6&" alt="Lure Shrimp"/>
</p>

## Features
### Lure allows you to...
- add Custom cosmetics of all kinds!
- add Custom Species with modded and vanilla pattern compatibility (and custom voices)!
- add Custom patterns for Vanilla AND modded species!

### ...it also makes modding easier and less annoying with the following tweaks :)
- Updates the character colors shader so now patterns can have additional static colors on their textures.
- Aside from cosmetics, also allows you to load custom item resources into the game with a single line of code (per item).
- Items/Cosmetics loaded with lure have a unique prefix related to the mod's folder they were loaded from, allowing multiple mods to have same the same item/cosmetic file names.
- Streamlines the process of finding your mod's assets by using Lure's ```mod://``` prefix when referencing assets inside the mod's folder.

## Requirements
- [GDWeave](https://github.com/NotNite/GDWeave/tree/main)

## How to Install
- drag the folder inside the release's zip into ```<game install folder>\GDWeave\mods```

## Development
if your mod depends on Lure in any way, make sure to add ```"Sulayre.Lure"``` to the ```"Dependencies"``` array of your mod's manifest.json

```dependencies: ["Sulayre.Lure"]```

To access Lure's functions in your code, add the following line at the start of main.gd:

```onready var Lure = get_node("/root/SulayreLure")```

*(this way you can access all of it's functions listed below in the Documentation)*

## Documentation

<pre class="github-dark-default" style="background-color:#0d1117;color:#e6edf3" tabindex="0"><code><div class="line"><span style="color:#8B949E"># Make sure you run these functions on the _ready() command of your mod.gd!</span></div><div class="line"><span style="color:#8B949E"># (assign first, then add content)</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E"># a cosmetic or items' ID is composed of &#x3C;mod_id.resource_id></span></div><div class="line"><span style="color:#8B949E"># (the resource id is the identifier given to the resource via add_content())</span></div><div class="line"><span style="color:#8B949E"># for example, if we run add_content(my_mod,pizza) the final id of the resource</span></div><div class="line"><span style="color:#8B949E"># will be my_mod.pizza, this is to avoid a mod overwriting other mods</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E">#[==================================================================================================]</span></div><div class="line">
</div><div class="line"><span style="color:#79C0FF">	assign_pattern_texture</span><span style="color:#E6EDF3">(</span><span style="color:#A5D6FF">"&#x3C;mod folder name (ID)>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"&#x3C;pattern id>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"&#x3C;species id>"</span><span style="color:#E6EDF3">, </span><span style="color:#A5D6FF">"mod://&#x3C;asset path starting from your mod's folder>"</span><span style="color:#E6EDF3">)</span></div><div class="line"><span style="color:#8B949E">#                                |                    |               |                              |</span></div><div class="line"><span style="color:#8B949E">#                                |                    |               |                              L we give the assigner a path that begins in the main folder of the mod for the texture</span></div><div class="line"><span style="color:#8B949E">#                                |                    |               |</span></div><div class="line"><span style="color:#8B949E">#                                |                    |               L we tell the assigner what is the id of the species this pattern texture will be for</span></div><div class="line"><span style="color:#8B949E">#                                |                    |               </span></div><div class="line"><span style="color:#8B949E">#                                |                    L we tell the assigner what is the id of the pattern we're adding texture to</span></div><div class="line"><span style="color:#8B949E">#                                |</span></div><div class="line"><span style="color:#8B949E">#                                L we tell the assigner in what mod the texture will be</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E"># assigning pattern textures for vanilla species is optional unless you're overwriting, just replace</span></div><div class="line"><span style="color:#8B949E"># the index for the corresponding vanilla texture in the resource's body pattern:</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E"># 0 -> Body texture</span></div><div class="line"><span style="color:#8B949E"># 0 -> Cat texture</span></div><div class="line"><span style="color:#8B949E"># 0 -> Dog texture</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E">#[==================================================================================================]</span></div><div class="line">
</div><div class="line"><span style="color:#79C0FF">	assign_face_animation</span><span style="color:#E6EDF3">(</span><span style="color:#A5D6FF">"&#x3C;mod folder name (ID)>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"&#x3C;species_id>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"&#x3C;mod://&#x3C;asset path starting from your mod's folder>"</span><span style="color:#E6EDF3">)</span></div><div class="line"><span style="color:#8B949E">#                                |                     |                           |                                               </span></div><div class="line"><span style="color:#8B949E">#                                |                     |                           L we give the assigner a path that begins in the main folder of the mod for the animation resource</span></div><div class="line"><span style="color:#8B949E">#                                |                     |               </span></div><div class="line"><span style="color:#8B949E">#                                |                     L we tell the assigner what is the id of species that we're assigning face offsets to</span></div><div class="line"><span style="color:#8B949E">#                                |</span></div><div class="line"><span style="color:#8B949E">#                                L we tell the assigner in what mod the texture will be</span></div><div class="line">
</div><div class="line"><span style="color:#8B949E">#[==================================================================================================]</span></div><div class="line">
</div><div class="line"><span style="color:#79C0FF">	assign_species_voice</span><span style="color:#E6EDF3">(</span><span style="color:#A5D6FF">"&#x3C;mod folder name (ID)>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"&#x3C;species_id>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"mod://&#x3C;bark sound relative path>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"mod://&#x3C;optional growl sound relative path>"</span><span style="color:#E6EDF3">,</span><span style="color:#A5D6FF">"mod://&#x3C;optional whine sound relative path>"</span><span style="color:#E6EDF3">)</span></div><div class="line"><span style="color:#8B949E">#                                |                   |                           |                                               </span></div><div class="line"><span style="color:#8B949E">#                                |                   |                           L we give the assigner 3 paths separately for the audio assets, the bark is obligatory, but the growl and whine are optional.</span></div><div class="line"><span style="color:#8B949E">#                                |                   |               </span></div><div class="line"><span style="color:#8B949E">#                                |                   L we tell the assigner what is the id of species that we're assigning the bark, growl and whine sounds to</span></div><div class="line"><span style="color:#8B949E">#                                |</span></div><div class="line"><span style="color:#8B949E">#                                L we tell the assigner in what mod the texture will be</span></div><div class="line">
</div></code></pre>

*(Logo drawn by [ZeaTheMays](https://github.com/ZeaTheMays))*
