![Icon](https://raw.githubusercontent.com/connorhaigh/Provisum/master/Icon.png)

# Provisum

Provisum is a C# library to assist with general application development.

## Overview

Provisum aims to be a library that provides a set of functionality that is sufficient to aid the basics of the development of a multitude of applications, but not so much that is starts to become cumbersome. It is primarily designed to be used within a desktop context, but is not exclusively limited to just the desktop.

### Provisum

Provides the core set of functionality with the main feature being a collection of different services that wrap a lot of common boilerplate functionality designed to be used with dependency injection, along with accompanying implementations. This includes file system access, network calls, and so on.

### Provisum.Mvvm

Provides the core set of functionality relating to the MVVM architecture primarily used within WPF. This includes an implementation of `ICommand`, an implementation of `INotifyPropertyChanged` for base view models, and an implementation of `IDataErrorInfo` for models.

### Provisum.Wpf

Provides an additional set of functionality for WPF not solely tied to a particular architecture. This includes a few useful implementations of `IValueConverter` for use in data binding, some WPF-specific service implementations, and some WPF utility methods.

### Provisum.Wpf.Mvvm

Provides a supplementary set of functionality for WPF when used within the MVVM architecture. The main feature is the collection of various common views for dialogs, and a window service for mapping view models to windows directly.

### Provisum.Mvp

Provides no real functionality at the moment other than as a placeholder for future MVP architecture related features.
