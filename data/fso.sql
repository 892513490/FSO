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
  `creator_id` bigint(20) DEFAULT NULL,
  `creator` varchar(50) DEFAULT '',
  `create_date` timestamp DEFAULT now(),
  `modify_date` timestamp DEFAULT now(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

alter table `t_urlinfo` MODIFY COLUMN `create_date` DEFAULT CURRENT_TIMESTAMP;
alter table `t_urlinfo` MODIFY COLUMN `modify_date` DEFAULT CURRENT_TIMESTAMP;

-- ----------------------------
-- Table structure for t_videoinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_videoinfo`;
CREATE TABLE `t_videoinfo` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT '',
  `author` varchar(50) DEFAULT '',
  `remark` varchar(500) DEFAULT '',
  `url` varchar(200) DEFAULT '',
  `img_url` varchar(200) DEFAULT '',
  `creator_id` bigint(20) DEFAULT NULL,
  `creator` varchar(50) DEFAULT '',
  `create_date` timestamp DEFAULT current_timestamp NULL,
  `modify_date` timestamp DEFAULT current_timestamp NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;


alter table `t_videoinfo` MODIFY COLUMN `create_date` DEFAULT CURRENT_TIMESTAMP;
alter table `t_videoinfo` MODIFY COLUMN `modify_date` DEFAULT CURRENT_TIMESTAMP;
