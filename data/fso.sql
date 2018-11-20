/*
Navicat MySQL Data Transfer

Source Server         : fso-pro
Source Server Version : 50560
Source Host           : 47.107.80.29:3306
Source Database       : fso

Target Server Type    : MYSQL
Target Server Version : 50560
File Encoding         : 65001

Date: 2018-11-20 21:57:53
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_urlinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_urlinfo`;
CREATE TABLE `t_urlinfo` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT '',
  `url` varchar(200) DEFAULT '',
  `remark` varchar(500) DEFAULT '',
  `createdate` date DEFAULT NULL,
  `modifydate` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of t_urlinfo
-- ----------------------------
INSERT INTO `t_urlinfo` VALUES ('1', 'fsonline', 'https://www.fsonline.vip', '', '2018-11-20', '2018-11-20');
INSERT INTO `t_urlinfo` VALUES ('2', '???', 'https://www.aliyun.com', '', '2018-11-20', '2018-11-20');
INSERT INTO `t_urlinfo` VALUES ('3', '??', 'https://www.baidu.com', '', '2018-11-20', '2018-11-20');

-- ----------------------------
-- Table structure for t_userinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_userinfo`;
CREATE TABLE `t_userinfo` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `account` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `sex` int(11) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `createdate` date DEFAULT NULL,
  `modifydate` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of t_userinfo
-- ----------------------------
INSERT INTO `t_userinfo` VALUES ('1', 'admin', '123456', '', null, null, null, null, null);
