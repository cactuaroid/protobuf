﻿using System;
using System.IO;

namespace Google.ProtocolBuffers {
  /// <summary>
  /// Thrown when a protocol message being parsed is invalid in some way,
  /// e.g. it contains a malformed varint or a negative byte length.
  /// 
  /// TODO(jonskeet): Make the methods throw directly? Rename them?
  /// </summary>
  public class InvalidProtocolBufferException : IOException {

    private InvalidProtocolBufferException(string message)
      : base(message) {
    }

    internal static InvalidProtocolBufferException TruncatedMessage() {
      return new InvalidProtocolBufferException(
        "While parsing a protocol message, the input ended unexpectedly " +
        "in the middle of a field.  This could mean either than the " +
        "input has been truncated or that an embedded message " +
        "misreported its own length.");
    }

    internal static InvalidProtocolBufferException NegativeSize() {
      return new InvalidProtocolBufferException(
        "CodedInputStream encountered an embedded string or message " +
        "which claimed to have negative size.");
    }

    internal static InvalidProtocolBufferException MalformedVarint() {
      return new InvalidProtocolBufferException(
        "CodedInputStream encountered a malformed varint.");
    }

    internal static InvalidProtocolBufferException InvalidTag() {
      return new InvalidProtocolBufferException(
        "Protocol message contained an invalid tag (zero).");
    }

    internal static InvalidProtocolBufferException InvalidEndTag() {
      return new InvalidProtocolBufferException(
        "Protocol message end-group tag did not match expected tag.");
    }

    internal static InvalidProtocolBufferException InvalidWireType() {
      return new InvalidProtocolBufferException(
        "Protocol message tag had invalid wire type.");
    }

    internal static InvalidProtocolBufferException RecursionLimitExceeded() {
      return new InvalidProtocolBufferException(
        "Protocol message had too many levels of nesting.  May be malicious.  " +
        "Use CodedInputStream.setRecursionLimit() to increase the depth limit.");
    }

    internal static InvalidProtocolBufferException SizeLimitExceeded() {
      return new InvalidProtocolBufferException(
        "Protocol message was too large.  May be malicious.  " +
        "Use CodedInputStream.setSizeLimit() to increase the size limit.");
    }
  }
}
