# E2E使用文档

![image-20250106200224820](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250106200224820.png)

## 简介

E2E(Excel to Everything)是一个Excel格式转换工具，你可以使用将Excel转换成 任何! 你想要的格式，如json、xml、lua、proto等，甚至是Unity的Scriptable Object这样在细分领域需要的格式，或者你自创的格式。如果你需要的格式和转换规则没有被默认给出，下文也会告诉你如何编写适配该工具的dll，将dll放置在指定位置，你就可以使用自定义的格式转换规则啦~当我们编写dll足够多，这个工具就能真正的实现Excel万用转换。

## 快速开始

### 获得E2E的可运行文件

你可以从github releases页面中找到最新的E2E可运行文件

### 目标格式

打开可运行文件，你将看到如下页面

你需要选择你想要的目标格式，如json，点击下拉菜单，选择json

### 配置

点击Config，确保当前配置是正确的。通常需要注意的是ExcelPath和JsonPath，前者是读取Excel的路径，你需要将xsl或xlsx文件放置在该路径下。点击左下角Refresh可以

### 转换数据

在左侧列表中选择你点击左下角Convert，

## Excel表结构



## 转换规则细节

## 自定义转换格式

如果你想自定义格式转换规则，你需要编写适配E2E的converter dll

### 创建项目

首先，你需要创建一个C#类库项目

### 类定义

你的程序集中需要定义命名空间Converter，和类型Converter.Converer

该类需要定义以下成员

- 有固定声明的Convert函数

```C#

```

- Setting字段
- Name字段

### 编译并放置到指定位置

