<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text" />
  <xsl:variable name="separator" select="'&#59;'" />
  <xsl:variable name="newline" select="'&#10;'" />

  <xsl:template match="/">
    <xsl:text>decimalNumber;hexadecimalNumber</xsl:text>
    <xsl:value-of select="$newline" />
    <xsl:for-each select="//NumberPair" >
      <xsl:value-of select="DecimalNumber" />
      <xsl:value-of select="$separator" />
      <xsl:value-of select="HexadecimalNumber" />
      <xsl:value-of select="$separator"/>
      <xsl:value-of select="$newline" />
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
