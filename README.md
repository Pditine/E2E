# E2E使用文档

![image-20250106200224820](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250106200224820.png)

## 简介

E2E(Excel to Everything)是一个Excel格式转换工具，你可以将Excel转换成任何!!你想要的格式，如json、xml、lua等，甚至是Unity的Scriptable Object这样在细分领域需要的格式，又或者你自创的格式。如果你需要的格式和转换规则没有被默认给出，下文也会告诉你如何编写适配该工具的dll，将dll放置在指定位置，你就可以使用自定义的格式转换规则啦。当我们编写dll足够多，这个工具就能真正的实现Excel万用转换。

## 快速开始

### 获得E2E的可运行文件

你可以从github releases页面中找到最新的E2E可运行文件

### 选择目标格式（转换器）

打开可运行文件，你将看到如下页面

![image-20250106200224820](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250106200224820.png)

你需要选择你想要的转换器，如json。点击下拉菜单，选择json

![image-20250301202851657](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250301202851657.png)

### 设置

点击Setting，确保当前设置是正确的。通常需要注意选项的是ExcelPath，这是E2E读取Excel的路径，你需要将xsl或xlsx文件放置在该路径下。

![image-20250301202753968](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250301202753968.png)

### 转换数据

在左侧列表中选择你希望转换的Excel文件，点击左下角的Convert按钮

![image-20250301202828545](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250301202828545.png)

## Excel表结构

常用的表结构如下

![image-20250301202550717](https://tuchuange.oss-cn-beijing.aliyuncs.com/img/image-20250301202550717.png)

- 第一行是字段解释
- 第二行是字段类型
- 第三行是字段名称
- 第四行用于设置tag，大小写不敏感
- 第五行之后的每一行表示一个数据对象

根据选取的转换器，表结构在具体使用时可能会有所变化。

### 默认转换器

[Json](./JsonConverter/README.md)

[Unity_SO](./UnityScriptableObjectConverter/README.md)

[PFC_Json](./PFCJsonConverter/README.md)

## 自定义转换器(编写中)

如果你想自定义转换器和格式转换规则，你需要编写适配E2E的dll

### 创建项目

首先，我们创建一个C#类库项目

### 类定义

我们的程序集中需要定义命名空间Converter，和类型Converter.Converer

该类需要定义以下成员

- 有固定声明的Convert函数

```C#

```

- Setting字段
- Name字段

### 编译并放置到指定位置

