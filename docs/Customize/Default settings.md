---
title: Default settings
---

``` yaml title="sharplog.yml"
format: '$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\n}$$Sp{\n}$'
levels:
  debug:
    short: '?'
    enabled: true
    format: null
  trace:
    short: '&'
    enabled: true
    format: null
  info:
    short: '+'
    enabled: true
    format: null
  warn:
    short: '!'
    enabled: true
    format: null
  error:
    short: 'x'
    enabled: true
    format: null
  fatal:
    short: 'X'
    enabled: true
    format: null
outputs:
  console:
    levels: null
    format: null
    color_enabled: true
    colors:
      debug:
        background: black
        foreground: darkGray
      trace:
        background: black
        foreground: white
      info:
        background: black
        foreground: green
      warn:
        background: black
        foreground: yellow
      error:
        background: black
        foreground: red
      fatal:
        background: red
        foreground: black
  file:
    levels: null
    format: null
    path: .log
    suspend_time: 500
```
