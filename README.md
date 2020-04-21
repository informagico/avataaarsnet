# AvataaarsNet - The .NET Component for Avataaars

![](./assets/logo.png)

This is a WPF Component porting of [Avataaars Generator](https://github.com/fangpenlin/avataaars-generator) by [Fang-Pen Lin](https://twitter.com/fangpenlin).

## Features

- Built on top of .NET Framework 4.7.2
- Uses the https://avataaars.io endpoint for generate the images (can also be self-hosted, see [below](#thanks))

## Usage

Add the reference to the namespace AvataaarsNet in your project and in your XAML.

```xaml
xmlns:avataaarsnet="clr-namespace:AvataaarsNet;assembly=AvataaarsNet"
```

Add the component in your XAML

```xaml
<avataaarsnet:AvataaarsGenerator x:Name="Avataaaars"/>
```

It exposes a DependencyProperty *`AvataaarsImage`* with the resulting `Bitmap` image.

## Thanks

Special thanks to [@gkoberger](https://github.com/gkoberger) for porting the React component server side and deploying it to https://avataaars.io  
This can also be self-hosted, refer to its [repository](https://github.com/gkoberger/avataaars) for further details.
